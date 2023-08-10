using MediatR;
using FluentResults;
using Infrastructure;

namespace Application.User;

public class GetUsersRequest : IRequest<Result<IEnumerable<Core.Entities.User>>>
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, Result<IEnumerable<Core.Entities.User>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUsersHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<IEnumerable<Core.Entities.User>>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var result = new Result<IEnumerable<Core.Entities.User>>();

            var users = await _unitOfWork.User.GetAllAsync();
            return result.WithValue(users);
        }
    }
}
