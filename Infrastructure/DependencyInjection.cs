//using System.Data;
//using wallet.lib.dapper;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System.Data.SqlClient;

//namespace Infrastructure
//{
//    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
//    {
//        services.AddTransient<IUserRepo, UserRepo>();
//        services.AddTransient<DbSession>();

//        var connectionString = configuration.GetConnectionString("SqlConnection");
//        services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));

//        return services;
//    }
//}
