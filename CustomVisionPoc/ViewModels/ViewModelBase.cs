using CommunityToolkit.Mvvm.ComponentModel;
using CustomVisionPoc.Services;

namespace CustomVisionPoc.ViewModels
{
    public abstract partial class ViewModelBase : ObservableObject
    {
        protected ISettingsService SettingsService { get; }
        protected INavigationService NavigationService { get; }

        public ViewModelBase(ISettingsService settingsService, INavigationService navigationService)
        {
            SettingsService = settingsService;
            NavigationService = navigationService;
        }

        public bool IsActive { get; set; }

        [ObservableProperty]
        private bool isBusy;

        public virtual void Activate(object parameter)
        {
        }

        public virtual void Deactivate()
        {
        }
    }
}
