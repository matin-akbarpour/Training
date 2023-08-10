using Dapper;
using Dapper.FastCrud;
using wallet.lib.dapper;

namespace Infrastructure.Repositories.User;

public class UserRepo : DapperRepository<Core.Entities.User, string>, IUserRepo
{
    public UserRepo(DbSession session) : base(session) { }
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Core.Entities.User>> LoginUser(Core.Entities.User user)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserName", user.UserName);
        parameters.Add("Password", user.Password);
        
        var userData = await QueryAsync("WHERE UserName=@UserName AND Password=@Password", parameters);
        return userData.ToList();
    }
    // --------------------------------------------------------------------------------------------
    public async Task<Core.Entities.User?> UserById(string? userName)
    {
        var userData = await Session.Connection.GetAsync(new Core.Entities.User {UserName=userName});
        return userData;
    }
}
