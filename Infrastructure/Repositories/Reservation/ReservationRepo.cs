using Dapper;
using System.Data;
using Dapper.FastCrud;
using Infrastructure.Models;

namespace Infrastructure.Repositories.Reservation;

public class ReservationRepo : IReservationRepo
{
    private readonly IDbConnection _dbConnection;
    public ReservationRepo(IDbConnection dbConnection) => _dbConnection = dbConnection;
    // --------------------------------------------------------------------------------------------
    public async Task RegisterReservation(Reservations reservation)
    {
        await _dbConnection.QueryFirstOrDefaultAsync("ResetReservationID", commandType: CommandType.StoredProcedure);
        await _dbConnection.InsertAsync(reservation);
    }
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Core.Entities.Reservation>> GetReservations()
    {
        const string query = "SELECT * FROM Reservations";
        var reservation = await _dbConnection.QueryAsync<Core.Entities.Reservation>(query);
        return reservation.ToList();
    }
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Reservations>> CheckReservation(Reservations reservation)
    {
        const string query = "SELECT * FROM Reservations WHERE LocationID=@LocationID AND ReservationDate=@ReservationDate";
        var reservationData = await _dbConnection.QueryAsync<Reservations>(query, reservation);
        return reservationData.ToList();
    }
}
