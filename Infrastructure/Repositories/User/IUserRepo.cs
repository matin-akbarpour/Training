using wallet.lib.dapper;

namespace Infrastructure.Repositories.User;

public interface IUserRepo : IRepository<Core.Entities.User, string>
{
    public Task<IEnumerable<Core.Entities.User>> LoginUser(Core.Entities.User user);
    public Task<Core.Entities.User?> UserById(string? userName);
}
