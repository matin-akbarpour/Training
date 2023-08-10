using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
