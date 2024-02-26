using Mde.Storage.StorageBasics.ViewModels;

namespace Mde.Storage.StorageBasics.Pages;

public partial class ImageCachingPage : ContentPage
{
	public ImageCachingPage(ImageCachingViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}