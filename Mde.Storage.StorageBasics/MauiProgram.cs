using Mde.Storage.StorageBasics.Domain.Services;
using Mde.Storage.StorageBasics.Pages;
using Mde.Storage.StorageBasics.ViewModels;
using Microsoft.Extensions.Logging;

namespace Mde.Storage.StorageBasics
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            
            builder.Services.AddTransient<WalkthroughPage>();
            builder.Services.AddTransient<WalkthroughViewModel>();

            Routing.RegisterRoute(nameof(WalkthroughPage), typeof(WalkthroughPage));

            builder.Services.AddTransient<IWalkthroughService, AppPackageWalkthroughService>();


            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
