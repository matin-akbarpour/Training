using wallet.lib.dapper;

namespace Infrastructure.Repositories.Reservation;

public interface IReservationRepo : IRepository<Core.Entities.Reservation, int>
{
    public Task<IEnumerable<Core.Entities.Reservation>> CheckReservation(Core.Entities.Reservation reservation);
}
