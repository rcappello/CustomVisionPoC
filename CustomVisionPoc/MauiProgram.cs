using CommunityToolkit.Maui;
using CustomVisionPoc.Services;
using Microsoft.Extensions.Logging;

namespace CustomVisionPoc
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureEffects(effects =>
                {

                })
                .UseMauiCommunityToolkit()
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font_Awesome_5_Free-Regular-400.otf", "FontAwesome-Regular");
                    fonts.AddFont("Font_Awesome_5_Free-Solid-900.otf", "FontAwesome-Solid");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IPermissionService, PermissionService>();
            mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
            mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<ViewModels.MainViewModel>();
            mauiAppBuilder.Services.AddTransient<ViewModels.SettingsViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();
            mauiAppBuilder.Services.AddTransient<SettingsPage>();

            return mauiAppBuilder;
        }
    }
}