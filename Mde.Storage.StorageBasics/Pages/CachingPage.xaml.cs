using Mde.Storage.StorageBasics.ViewModels;

namespace Mde.Storage.StorageBasics.Pages;

public partial class CachingPage : ContentPage
{
	public CachingPage(CachingViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}