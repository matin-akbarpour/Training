using Dapper;
using Infrastructure.Models;

namespace Infrastructure.Repositories.Location;

public interface ILocationRepo
{
    public Task<IEnumerable<Core.Entities.Location>> GetLocations(DynamicParameters parameters);
    public Task RegisterLocation(Locations location);
    public Task UpdateLocation(int id, Locations location);
    public Task DeleteLocation(int id);
    public Task<IEnumerable<Locations>> LocationById(int id);
}
