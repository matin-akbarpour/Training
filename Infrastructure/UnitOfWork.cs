using Infrastructure.Repositories.User;
using Infrastructure.Repositories.Location;
using Infrastructure.Repositories.Reservation;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public IUserRepo User { get; }
    
    public ILocationRepo Location { get; }
    
    public IReservationRepo Reservation { get; }
    
    public UnitOfWork(IUserRepo userRepo, ILocationRepo locationRepo, IReservationRepo reservationRepo)
    {
        User = userRepo;
        Location = locationRepo;
        Reservation = reservationRepo;
    }
}
