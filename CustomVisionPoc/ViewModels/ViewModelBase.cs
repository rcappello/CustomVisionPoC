using CommunityToolkit.Mvvm.ComponentModel;
using CustomVisionPoc.Services;

namespace CustomVisionPoc.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        protected ISettingsService SettingsService { get; }
        protected INavigationService NavigationService { get; }

        public ViewModelBase(ISettingsService settingsService, INavigationService navigationService)
        {
            SettingsService = settingsService;
            NavigationService = navigationService;
        }

        public bool IsActive { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetBusy(value) && !isBusy)
                {
                    BusyMessage = null;
                }
            }
        }

        private string busyMessage;
        public string BusyMessage
        {
            get => busyMessage;
            set => SetProperty(ref busyMessage, value);
        }

        public bool SetBusy(bool value, string message = null)
        {
            BusyMessage = message;

            var isSet = SetProperty(ref isBusy, value);
            if (isSet)
            {
                OnIsBusyChanged();
            }

            return isSet;
        }

        protected virtual void OnIsBusyChanged()
        {
        }

        public virtual void Activate(object parameter)
        {
        }

        public virtual void Deactivate()
        {
        }

        protected async Task ShowErrorAsync(string message, Exception ex = null)
        {
            //DialogService.HideLoading();
            //await DialogService.AlertAsync(message);
        }
    }


}
