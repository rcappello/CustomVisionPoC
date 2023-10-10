using CustomVisionPoc.Services;

namespace CustomVisionPoc
{
    public partial class App : Application
    {
        private readonly INavigationService navigationService;

        public static bool IsPausing { get; set; }

        public App(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            InitializeComponent();

            MainPage = new AppShell(navigationService);
        }
    }
}