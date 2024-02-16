﻿using Mde.Storage.StorageBasics.Domain.Services;
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
            
            builder.Services.AddTransient<CoffeeListPage>();
            builder.Services.AddTransient<CoffeeListViewModel>();

            builder.Services.AddTransient<BrewPage>();
            builder.Services.AddTransient<BrewViewModel>();

            Routing.RegisterRoute(nameof(CoffeeListPage), typeof(CoffeeListPage));
            Routing.RegisterRoute(nameof(BrewPage), typeof(BrewPage));

            builder.Services.AddTransient<ICoffeeService, AppPackageCoffeeService>();
            builder.Services.AddTransient<ICoffeeLoggingService, LocalLoggingService>();


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
