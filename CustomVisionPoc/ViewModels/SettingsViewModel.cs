using CommunityToolkit.Mvvm.Input;
using CustomVisionPoc.Common;
using CustomVisionPoc.Services;

namespace CustomVisionPoc.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        public string PredictionServiceName
        {
            get => SettingsService.PredictionServiceName;
            set => SettingsService.PredictionServiceName = value;
        }

        public string IterationName
        {
            get => SettingsService.IterationName;
            set => SettingsService.IterationName = value;
        }

        public string PredictionKey
        {
            get => SettingsService.PredictionKey;
            set => SettingsService.PredictionKey = value;
        }

        public string ProjectId
        {
            get => SettingsService.ProjectId;
            set => SettingsService.ProjectId = value;
        }

        public SettingsViewModel(ISettingsService settingsService, INavigationService navigationService)
        : base(settingsService, navigationService)
        {

        }

        [RelayCommand]
        private async Task OpenCustomVisionWebSite()
        {
            await Browser.Default.OpenAsync(Constants.CustomVisionPortal, BrowserLaunchMode.SystemPreferred);
        }
    }
}
