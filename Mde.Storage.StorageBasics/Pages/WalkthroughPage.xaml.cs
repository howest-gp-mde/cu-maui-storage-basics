using Mde.Storage.StorageBasics.ViewModels;

namespace Mde.Storage.StorageBasics.Pages;

public partial class WalkthroughPage : ContentPage
{
	public WalkthroughPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        var viewmodel = BindingContext as WalkthroughViewModel;
        viewmodel?.OnAppearing?.Execute(null);
    }
}