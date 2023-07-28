using Infrastructure.Models;

namespace Infrastructure.Repositories.Reservation;

public interface IReservationRepo
{
    public Task RegisterReservation(Reservations location);
    public Task<IEnumerable<Core.Entities.Reservation>> GetReservations();
    public Task<IEnumerable<Reservations>> CheckReservation(Reservations reservation);
}
