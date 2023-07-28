using Dapper;
using System.Data;
using Dapper.FastCrud;
using Infrastructure.Models;

namespace Infrastructure.Repositories.Location;

public class LocationRepo : ILocationRepo
{
    private readonly IDbConnection _dbConnection;
    public LocationRepo(IDbConnection dbConnection) => _dbConnection = dbConnection;
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Core.Entities.Location>> GetLocations(DynamicParameters parameters)
    {
        var location = await _dbConnection.QueryAsync<Core.Entities.Location>("PagingFilteringLocations", parameters, commandType: CommandType.StoredProcedure);
        return location.ToList();
    }
    // --------------------------------------------------------------------------------------------
    public async Task RegisterLocation(Locations location)
    {
        await _dbConnection.QueryFirstOrDefaultAsync("ResetLocationID", commandType: CommandType.StoredProcedure);
        await _dbConnection.InsertAsync(location);
    }
    // --------------------------------------------------------------------------------------------
    public async Task UpdateLocation(int id, Locations location)
    {
        var parameters = new UpdateDeleteLocations()
        {
            LocationID = id,
            Title = location.Title,
            Address = location.Address,
            LocationType = location.LocationType,
            Geolocation = location.Geolocation
        };
        await _dbConnection.UpdateAsync(parameters);
    }
    // --------------------------------------------------------------------------------------------
    public async Task DeleteLocation(int id)
    {
        await _dbConnection.DeleteAsync(new UpdateDeleteLocations { LocationID = id });
    }
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Locations>> LocationById(int id)
    {
        const string query = "SELECT * FROM Locations WHERE LocationID=@LocationID";
        var location = await _dbConnection.QueryAsync<Locations>(query, new {LocationID=id});
        return location.ToList();
    }
}
