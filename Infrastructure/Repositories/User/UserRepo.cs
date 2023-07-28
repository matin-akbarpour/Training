using Dapper;
using System.Data;
using Dapper.FastCrud;
using Infrastructure.Models;

namespace Infrastructure.Repositories.User;

public class UserRepo : IUserRepo
{
    private readonly IDbConnection _dbConnection;
    public UserRepo(IDbConnection dbConnection) => _dbConnection = dbConnection;
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Users>> LoginUser(Users user)
    {
        const string query = "SELECT * FROM Users WHERE UserName=@UserName AND Password=@Password";
        var userData = await _dbConnection.QueryAsync<Users>(query, user);
        return userData.ToList();
    }
    // --------------------------------------------------------------------------------------------
    public async Task SignupUser(Users user)
    {
        await _dbConnection.InsertAsync(user);
    }
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Core.Entities.User>> GetUsers()
    {
        const string query = "SELECT * FROM Users";
        var user = await _dbConnection.QueryAsync<Core.Entities.User>(query);
        return user.ToList();
    }
    // --------------------------------------------------------------------------------------------
    public async Task<IEnumerable<Users>> CheckUser(Users user)
    {
        const string query = "SELECT * FROM Users WHERE UserName=@UserName";
        var userData = await _dbConnection.QueryAsync<Users>(query, new {user.UserName});
        return userData.ToList();
    }
}
