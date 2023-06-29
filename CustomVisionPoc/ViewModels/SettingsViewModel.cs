using CommunityToolkit.Mvvm.Input;
using CustomVisionPoc.Common;
using CustomVisionPoc.Services;

namespace CustomVisionPoc.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public string Region
        {
            get => SettingsService.Region;
            set => SettingsService.Region = value;
        }

        public string ProjectName
        {
            get => SettingsService.ProjectName;
            set => SettingsService.ProjectName = value;
        }

        public string PredictionKey
        {
            get => SettingsService.PredictionKey;
            set => SettingsService.PredictionKey = value;
        }

        public string IterationId
        {
            get => SettingsService.IterationId;
            set => SettingsService.IterationId = value;
        }

        public RelayCommand OpenCustomVisionWebSiteCommand { get; private set; }

        public SettingsViewModel(ISettingsService settingsService, INavigationService navigationService)
        : base(settingsService, navigationService)
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            OpenCustomVisionWebSiteCommand = new RelayCommand(async () => await Browser.Default.OpenAsync(Constants.CustomVisionPortal, BrowserLaunchMode.SystemPreferred));
        }
    }
}
