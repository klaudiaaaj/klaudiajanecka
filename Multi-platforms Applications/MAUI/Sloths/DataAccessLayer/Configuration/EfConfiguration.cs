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
            options.UseSqlServer("Server=sql5104.site4now.net;Initial Catalog=db_a9383d_sloths;Persist Security Info=False;User ID=db_a9383d_sloths_admin;Password=usr12345.;MultipleActiveResultSets=False;Connection Timeout=30;");
            
        }, ServiceLifetime.Transient);

        services.AddScoped<ISlothRepository, SlothRepository>();

        return services;
    }
}