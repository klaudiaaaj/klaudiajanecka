using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sloths.Repositories;

namespace DataAccessLayer.EfCoreConfiguration;

public static class EfCoreConfiguration
{
    public static IServiceCollection AddEfCore(this IServiceCollection services)
    {
        services.AddDbContext<SlothDbContetxt>(options =>
        {
            options.UseSqlServer("Server=tcp:dotnetsloths.database.windows.net,1433;Initial Catalog=dotnetsloths;Persist Security Info=False;User ID=user;Password=usr12345.;MultipleActiveResultSets=False;Connection Timeout=30;");
            
        }, ServiceLifetime.Transient);

        services.AddScoped<ISlothRepository, SlothRepository>();

        return services;
    }
}