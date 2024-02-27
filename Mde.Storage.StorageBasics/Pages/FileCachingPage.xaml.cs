using Mde.Storage.StorageBasics.ViewModels;

namespace Mde.Storage.StorageBasics.Pages;

public partial class FileCachingPage : ContentPage
{
	public FileCachingPage(FileCachingViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as FileCachingViewModel).OnAppearingCommand.Execute(null);
    }
}