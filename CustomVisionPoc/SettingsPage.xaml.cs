using CustomVisionPoc.Common;
using CustomVisionPoc.ViewModels;

namespace CustomVisionPoc;

public partial class SettingsPage : ContentPageBase
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}