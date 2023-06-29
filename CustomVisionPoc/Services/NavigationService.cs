namespace CustomVisionPoc.Services
{
    public enum HistoryBehavior
    {
        Default,
        ClearHistory
    }

    public class NavigationService : INavigationService
    {
        private readonly ISettingsService _settingsService;

        public NavigationService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Task InitializeAsync() => NavigateToAsync("//MainPage");

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation);
        }

        public Task PopAsync() =>
            Shell.Current.GoToAsync("..");
    }
}
