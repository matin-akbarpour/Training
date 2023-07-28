using Infrastructure.Repositories.User;
using Infrastructure.Repositories.Location;
using Infrastructure.Repositories.Reservation;

namespace Infrastructure;

public interface IUnitOfWork
{
    public IUserRepo User { get; }
    
    public ILocationRepo Location { get; }
    
    public IReservationRepo Reservation { get; }
}
