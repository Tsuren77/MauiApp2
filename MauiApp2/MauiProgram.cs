using MauiApp2.Servicios;
using MauiApp2.View;
using MauiApp2.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiApp2;

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
        
        builder.Services.AddSingleton<IRickAndMortyService,RickAndMortyService>();
        
        builder.Services.AddTransient<HomeView> ();
        builder.Services.AddTransient<HomeViewModel> ();
        builder.Services.AddTransient<PrimerNivelView> ();
        builder.Services.AddTransient<PrimerViewModel> ();
        builder.Services.AddTransient<AboutView>();
        builder.Services.AddTransient<AboutViewModel>();
        builder.Services.AddTransient<SettingView>();
        builder.Services.AddTransient<SettingViewModel>();
        

#if DEBUG
        builder.Logging.AddDebug();
        
       
#endif

        return builder.Build();
    }
}