using MediatR;
using Infrastructure;
using Application.User;
using Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Application.Location;

public class RegisterLocationCommand : IRequest<string>
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public string? LocationType { get; set; }
    [Required]
    public string? Geolocation { get; set; }
   
    public class RegisterLocationHandler : IRequestHandler<RegisterLocationCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterLocationHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<string> Handle(RegisterLocationCommand command, CancellationToken cancellationToken)
        {
            var location = new Locations
            {
                Title = command.Title,
                Address = command.Address,
                LocationType = command.LocationType,
                Geolocation = command.Geolocation,
                RegistrarUserName = LoginUserCommand.LoginUserHandler._userName
            };

            if (location.RegistrarUserName.IsNullOrEmpty())
                return "You should login first";

            await _unitOfWork.Location.RegisterLocation(location);
            return "Location registered";
        }
    }
}
