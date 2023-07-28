using MediatR;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.IdentityModel.Tokens;

namespace Application.Location;

public class UpdateLocationCommand : IRequest<string>
{
    public int Id { get; set; }
    public JsonPatchDocument<Locations>? PatchDocument { get; set; }

    public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLocationHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<string> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
        {
            if (command.PatchDocument == null || command.Id <= 0)
                return "Bad request";
            
            var location = await _unitOfWork.Location.LocationById(command.Id);
            if (location.IsNullOrEmpty())
                return "Location not found";
            
            foreach (var locations in location) command.PatchDocument.ApplyTo(locations);
            foreach (var locations in location) await _unitOfWork.Location.UpdateLocation(command.Id, locations);
            return "Location updated";
        }
    }
}
