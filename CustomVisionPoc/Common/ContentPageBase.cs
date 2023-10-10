using CommunityToolkit.Mvvm.Messaging;
using CustomVisionPoc.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace CustomVisionPoc.Common
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
            On<iOS>().SetUseSafeArea(true);
            //On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Never);
            Microsoft.Maui.Controls.NavigationPage.SetBackButtonTitle(this, string.Empty);
        }

        protected override void OnAppearing()
        {
            if (BindingContext is ViewModelBase viewModel && !viewModel.IsActive)
            {
                viewModel.Activate(null/*this.GetNavigationArgs()*/);
                viewModel.IsActive = true;
            }
            else if (App.IsPausing)
            {
                App.IsPausing = false;
            }

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            if (BindingContext is ViewModelBase viewModel && !App.IsPausing)
            {
                viewModel.Deactivate();
                viewModel.IsActive = false;
            }

            WeakReferenceMessenger.Default.UnregisterAll(this);
            base.OnDisappearing();
        }
    }
}
