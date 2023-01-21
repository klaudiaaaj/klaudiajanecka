using Microsoft.Extensions.Logging;
using DataAccessLayer.EfCoreConfiguration;
using Sloths.Repositories;
using Sloths.Services;
using Sloths.ViewModel;
using Sloths.Views;

namespace Sloths;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);
        builder.Logging.AddDebug();
        builder.Services.AddEfCore();

        builder.Services.AddSingleton<ISlothService, SlothService>();

        builder.Services.AddSingleton<SlothsViewModel>();
        builder.Services.AddTransient<SlothsDetailsViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<SlothsDetailsPage>();



#endif

        return builder.Build();
    }
}
