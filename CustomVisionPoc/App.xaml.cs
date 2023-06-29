using CustomVisionPoc.Services;

namespace CustomVisionPoc
{
    public partial class App : Application
    {
        private readonly INavigationService _navigationService;

        public static bool IsPausing { get; set; }

        public App(INavigationService navigationService)
        {
            _navigationService = navigationService;

            InitializeComponent();

            MainPage = new AppShell(navigationService);
        }
    }
}