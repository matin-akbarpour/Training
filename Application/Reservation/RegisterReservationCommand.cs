using MediatR;
using FluentResults;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Application.Reservation;

public class RegisterReservationCommand : IRequest<Result>
{
    [Required]
    public int LocationId { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }

    public class RegisterReservationHandler : IRequestHandler<RegisterReservationCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;
        
        public RegisterReservationHandler(IHttpContextAccessor accessor, IUnitOfWork unitOfWork)
        {
            _accessor = accessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterReservationCommand command, CancellationToken cancellationToken)
        {
            var result = new Result();
            
            var locationData = await _unitOfWork.Location.LocationById(command.LocationId);
            if (locationData == null)
                return result.WithSuccess("Location not found");
                
            var reservation = new Core.Entities.Reservation
            {
                RegistrationDate = DateTime.Now,
                ReservationDate = Convert.ToDateTime(command.ReservationDate.ToString("yyyy-MM-dd")),
                Cost = 10,
                RegistrarUserName = _accessor.HttpContext!.User.Claims.First(c => c.Type == "UserName").Value,
                LocationId = command.LocationId
            };
                
            var reservationData = await _unitOfWork.Reservation.CheckReservation(reservation);
            if (!reservationData.IsNullOrEmpty())
                return result.WithSuccess("This location is reserved on this date");
                
            await _unitOfWork.Reservation.ExecuteQueryAsync("EXECUTE ResetReservationID");
            await _unitOfWork.Reservation.InsertAsync(reservation);
            return result.WithSuccess("Location reserved");
        }
    }
}
