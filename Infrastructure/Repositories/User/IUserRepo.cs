using Infrastructure.Models;

namespace Infrastructure.Repositories.User;

public interface IUserRepo
{
    public Task<IEnumerable<Users>> LoginUser(Users user);
    public Task SignupUser(Users user);
    public Task<IEnumerable<Core.Entities.User>> GetUsers();
    public Task<IEnumerable<Users>> CheckUser(Users user);
}
