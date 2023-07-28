using MediatR;
using Infrastructure;

namespace Application.User;

public class GetUsersRequest : IRequest<IEnumerable<Core.Entities.User>>
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, IEnumerable<Core.Entities.User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUsersHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Core.Entities.User>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.User.GetUsers();
            return result;
        }
    }
}
