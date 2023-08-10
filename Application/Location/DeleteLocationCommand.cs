using MediatR;
using FluentResults;
using Infrastructure;

namespace Application.Location;

public class DeleteLocationCommand : IRequest<Result>
{
    public int Id { get; set; }
    
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteLocationHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result> Handle(DeleteLocationCommand command, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (command.Id <= 0)
                return result.WithSuccess("Id must be greater than 0");

            var locationData = await _unitOfWork.Location.LocationById(command.Id);
            if (locationData == null)
                return result.WithSuccess("Location not found");

            await _unitOfWork.Location.DeleteAsync(locationData);
            return result.WithSuccess("Location deleted");
        }
    }
}
