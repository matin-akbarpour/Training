using MediatR;
using FluentResults;
using Infrastructure;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Location;

public class UpdateLocationCommand : IRequest<Result>
{
    public int Id { get; set; }
    public JsonPatchDocument<Core.Entities.Location>? PatchDocument { get; set; }

    public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLocationHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (command.Id <= 0 || command.PatchDocument == null)
                return result.WithSuccess("Id must be greater than 0 or PatchDocument Shouldn't be null");
            
            var locationData = await _unitOfWork.Location.LocationById(command.Id);
            var locationDataCopy = await _unitOfWork.Location.LocationById(command.Id);
            if (locationData == null)
                return result.WithSuccess("Location not found");
                
            command.PatchDocument.ApplyTo(locationData);
                
            var location = new Core.Entities.Location
            {
                LocationId = command.Id,
                Title = locationData.Title,
                Address = locationData.Address,
                LocationType = locationData.LocationType,
                Geolocation = locationData.Geolocation,
                RegistrationDate = locationDataCopy!.RegistrationDate,
                RegistrarUserName = locationDataCopy.RegistrarUserName
            };
                
            await _unitOfWork.Location.UpdateAsync(location);
            return result.WithSuccess("Location updated");
        }
    }
}
