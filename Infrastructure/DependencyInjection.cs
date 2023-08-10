using System.Data;
using wallet.lib.dapper;
using Microsoft.Data.SqlClient;
using Infrastructure.Repositories.User;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories.Location;
using Infrastructure.Repositories.Reservation;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUserRepo, UserRepo>();
        services.AddTransient<ILocationRepo, LocationRepo>();
        services.AddTransient<IReservationRepo, ReservationRepo>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<DbSession>();

        var connectionString = configuration.GetConnectionString("SqlConnection");
        services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));
        
        return services;
    }
}
