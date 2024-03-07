using Mde.Storage.StorageBasics.ViewModels;

namespace Mde.Storage.StorageBasics.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }

    }

}
