using CustomVisionPoc.Common;
using CustomVisionPoc.ViewModels;

namespace CustomVisionPoc
{
    public partial class MainPage : ContentPageBase
    {
        public MainPage(MainViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}