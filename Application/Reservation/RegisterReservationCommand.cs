using MediatR;
using Infrastructure;
using Application.User;
using Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Application.Reservation;

public class RegisterReservationCommand : IRequest<string>
{
    [Required]
    public int LocationID { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }

    public class RegisterReservationHandler : IRequestHandler<RegisterReservationCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterReservationHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<string> Handle(RegisterReservationCommand command, CancellationToken cancellationToken)
        {
            var reservation = new Reservations
            {
                LocationID = command.LocationID,
                ReservationDate = command.ReservationDate,
                Cost = 10,
                RegistrarUserName = LoginUserCommand.LoginUserHandler._userName
            };
            
            if (reservation.RegistrarUserName.IsNullOrEmpty())
                return "You should login first";
            
            var location = await _unitOfWork.Location.LocationById(reservation.LocationID);
            if (location.IsNullOrEmpty())
                return "Location not found";
            
            reservation.ReservationDate = Convert.ToDateTime(reservation.ReservationDate.ToString("yyyy-MM-dd"));

            var reservationData = await _unitOfWork.Reservation.CheckReservation(reservation);
            if (!reservationData.IsNullOrEmpty())
                return "This location is reserved on this date";
            
            await _unitOfWork.Reservation.RegisterReservation(reservation);
            return "Location reserved";
        }
    }
}
