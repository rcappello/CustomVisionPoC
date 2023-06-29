namespace CustomVisionPoc.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            //var navigationService = App.Current.Handler.MauiContext.Services.GetService<INavigationService>();
            //navigationService.Configure(Constants.MainPage, typeof(MainPage));
            //navigationService.Configure(Constants.SettingsPage, typeof(SettingsPage));
        }

        static public MainViewModel MainViewModel => App.Current.Handler.MauiContext.Services.GetService<MainViewModel>();

        public SettingsViewModel SettingsViewModel => App.Current.Handler.MauiContext.Services.GetService<SettingsViewModel>();
    }
}
