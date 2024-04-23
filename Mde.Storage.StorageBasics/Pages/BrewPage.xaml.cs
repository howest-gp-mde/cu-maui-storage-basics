using Mde.Storage.StorageBasics.ViewModels;

namespace Mde.Storage.StorageBasics.Pages;

public partial class BrewPage : ContentPage
{
	public BrewPage(BrewViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}

    protected override void OnAppearing()
    {
        var viewmodel = BindingContext as BrewViewModel;
        viewmodel?.OnAppearingCommand?.Execute(null);
    }
}