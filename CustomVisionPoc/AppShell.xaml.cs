using CustomVisionPoc.Services;

namespace CustomVisionPoc
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService navigationService;

        public AppShell(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            AppShell.InitializeRouting();
            InitializeComponent();
        }

        protected override async void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            if (Handler is not null)
            {
                await navigationService.InitializeAsync();
            }
        }

        private static void InitializeRouting()
        {
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
        }
    }
}