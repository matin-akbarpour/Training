using Dapper;
using wallet.lib.dapper;

namespace Infrastructure.Repositories.Reservation;

public class ReservationRepo : DapperRepository<Core.Entities.Reservation, int>, IReservationRepo
{
    public ReservationRepo(DbSession session) : base(session) { }
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Core.Entities.Reservation>> CheckReservation(Core.Entities.Reservation reservation)
    {
        var parameters = new DynamicParameters();
        parameters.Add("LocationId", reservation.LocationId);
        parameters.Add("ReservationDate", reservation.ReservationDate);

        var reservationData = await QueryAsync("WHERE LocationId=@LocationId AND ReservationDate=@ReservationDate", parameters);
        return reservationData.ToList();
    }
}
