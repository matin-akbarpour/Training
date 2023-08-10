using MediatR;
using FluentResults;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Location;

public class RegisterLocationCommand : IRequest<Result>
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public string? LocationType { get; set; }
    [Required]
    public string? Geolocation { get; set; }
   
    public class RegisterLocationHandler : IRequestHandler<RegisterLocationCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;
        
        public RegisterLocationHandler(IHttpContextAccessor accessor, IUnitOfWork unitOfWork)
        {
            _accessor = accessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterLocationCommand command, CancellationToken cancellationToken)
        {
            var result = new Result();
            
            var location = new Core.Entities.Location
            {
                Title = command.Title,
                Address = command.Address,
                LocationType = command.LocationType,
                Geolocation = command.Geolocation,
                RegistrationDate = DateTime.Now,
                RegistrarUserName = _accessor.HttpContext!.User.Claims.First(c => c.Type == "UserName").Value
            };

            await _unitOfWork.Location.ExecuteQueryAsync("EXECUTE ResetLocationID");
            await _unitOfWork.Location.InsertAsync(location);
            return result.WithSuccess("Location registered");
        }
    }
}
