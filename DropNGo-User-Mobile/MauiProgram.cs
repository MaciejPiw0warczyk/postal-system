using DropNGo_User_Mobile.ViewModels;
using DropNGo_User_Mobile.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;



namespace DropNGo_User_Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif


        builder.Services.AddSingleton<ParcelList>();
        builder.Services.AddSingleton<ParcelListViewModel>();
        
        return builder.Build();
    }
}