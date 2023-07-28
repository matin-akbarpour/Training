using MediatR;
using Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace Application.Location;

public class DeleteLocationCommand : IRequest<string>
{
    public int Id { get; set; }
    
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteLocationHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<string> Handle(DeleteLocationCommand command, CancellationToken cancellationToken)
        {
            if (command.Id <= 0)
                return "Id must be greater than 0";
            
            var location = await _unitOfWork.Location.LocationById(command.Id);
            if (location.IsNullOrEmpty())
                return "Location not found";

            await _unitOfWork.Location.DeleteLocation(command.Id);
            return "Location deleted";
        }
    }
}
