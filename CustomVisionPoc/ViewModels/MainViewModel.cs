using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomVisionPoc.Common;
using CustomVisionPoc.Services;

namespace CustomVisionPoc.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IMediaService mediaService;

        [ObservableProperty]
        private IEnumerable<string> predictions;

        [ObservableProperty]
        private bool isOffline;

        [ObservableProperty]
        private string imagePath;

        public MainViewModel(ISettingsService settingsService, INavigationService navigationService, IMediaService mediaService)
        : base(settingsService, navigationService)
        {
            this.mediaService = mediaService;

            Predictions = new List<string>() { "CIAO CIAO", "CIAO CIAO CIAO" };
        }

        [RelayCommand]
        private async Task Settings()
        {
            await NavigationService.NavigateToAsync(Constants.SettingsPage);
        }

        [RelayCommand]
        private async Task TakePhoto()
        {
            await AnalyzePhotoAsync(() => mediaService.TakePhotoAsync());
        }

        [RelayCommand]
        private async Task PickPhoto()
        {
            await AnalyzePhotoAsync(() => mediaService.PickPhotoAsync());
        }

        private async Task AnalyzePhotoAsync(Func<Task<FileResult>> action)
        {
            IsBusy = true;

            try
            {
                var file = await action.Invoke();
                if (file != null)
                {
                    // Clean up previous results.
                    Predictions = null;
                    ImagePath = file.FullPath;

                    // Check whether to use the online or offline version of the prediction model.
                    //IEnumerable<Recognition> predictionsRecognized = null;
                    //if (isOffline)
                    //{
                    //    var classifier = CrossOfflineClassifier.Current;
                    //    predictionsRecognized = await classifier.RecognizeAsync(file.GetStream(), file.Path);
                    //}
                    //else
                    //{
                    //    var classifier = CrossOnlineClassifier.Current;
                    //    predictionsRecognized = await classifier.RecognizeAsync(SettingsService.Region, SettingsService.PredictionKey, SettingsService.ProjectName, Guid.Parse(SettingsService.IterationId), file.GetStream());
                    //}

                    //Predictions = predictionsRecognized.Select(p => $"{p.Tag}: {p.Probability:P1}");
                    //file.Dispose();
                }
            }
            catch (Exception ex)
            {
                //await DialogService.AlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
