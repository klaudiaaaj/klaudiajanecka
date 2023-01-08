using Microsoft.Extensions.Logging;
using DataAccessLayer.EfCoreConfiguration;
using Sloths.Repositories;
using Sloths.Services;

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
        builder.Logging.AddDebug();
        builder.Services.AddEfCore();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ISlothService, SlothService>();

#endif

        return builder.Build();
    }
}
