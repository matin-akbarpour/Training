using Dapper.FastCrud;
using wallet.lib.dapper;

namespace Infrastructure.Repositories.Location;

public class LocationRepo : DapperRepository<Core.Entities.Location, int>, ILocationRepo
{
    public LocationRepo(DbSession session) : base(session) { }
    // --------------------------------------------------------------------------------------------
    public async Task<Core.Entities.Location?> LocationById(int id)
    {
        var locationData = await Session.Connection.GetAsync(new Core.Entities.Location {LocationId=id});
        return locationData;
    }
}
