using wallet.lib.dapper;

namespace Infrastructure.Repositories.Location;

public interface ILocationRepo : IRepository<Core.Entities.Location, int>
{
    public Task<Core.Entities.Location?> LocationById(int id);
}
