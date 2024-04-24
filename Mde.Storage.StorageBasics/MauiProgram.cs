using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Mde.Storage.StorageBasics.Core.Services;
using Mde.Storage.StorageBasics.Pages;
using Mde.Storage.StorageBasics.Popups.ViewModels;
using Mde.Storage.StorageBasics.Popups.Views;
using Mde.Storage.StorageBasics.ViewModels;
using Microsoft.Extensions.Logging;

#if IOS
using AVFoundation;
#endif
namespace Mde.Storage.StorageBasics
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            
            builder.Services.AddTransient<CoffeeListPage>();
            builder.Services.AddTransient<CoffeeListViewModel>();

            builder.Services.AddTransient<BrewPage>();
            builder.Services.AddTransient<BrewViewModel>();

            builder.Services.AddTransient<ImageCachingPage>();
            builder.Services.AddTransient<ImageCachingViewModel>();

            builder.Services.AddTransient<FileCachingPage>();
            builder.Services.AddTransient<FileCachingViewModel>();

            Routing.RegisterRoute(nameof(CoffeeListPage), typeof(CoffeeListPage));
            Routing.RegisterRoute(nameof(BrewPage), typeof(BrewPage));
            Routing.RegisterRoute(nameof(ImageCachingPage), typeof(ImageCachingPage));
            Routing.RegisterRoute(nameof(FileCachingPage), typeof(FileCachingPage));

            builder.Services.AddTransient<ICoffeeService, AppPackageCoffeeService>();
            builder.Services.AddTransient<ICoffeeLoggingService, LocalLoggingService>();
            builder.Services.AddTransient<IVideoService, CacheVideoService>();

            builder.Services.AddTransientPopup<ConfirmPopup, ConfirmPopupViewModel>();


            builder
                .UseMauiApp<App>()
                .UseFFImageLoading()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
