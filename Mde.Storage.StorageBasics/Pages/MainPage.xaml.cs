using Mde.Storage.StorageBasics.ViewModels;

namespace Mde.Storage.StorageBasics
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }

    }

}
