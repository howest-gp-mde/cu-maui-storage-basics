using Mde.Storage.StorageBasics.ViewModels;

namespace Mde.Storage.StorageBasics.Pages;

public partial class CoffeeListPage : ContentPage
{
	public CoffeeListPage(CoffeeListViewModel viewmodel)
	{
		InitializeComponent();
        BindingContext = viewmodel;
	}

    protected override void OnAppearing()
    {
        var viewmodel = BindingContext as CoffeeListViewModel;
        viewmodel?.OnAppearingCommand?.Execute(null);
    }
}