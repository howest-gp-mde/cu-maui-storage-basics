using CommunityToolkit.Mvvm.ComponentModel;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public partial class ImageCachingViewModel : ObservableObject
    {
        public ImageSource CoffeePlantImage => new UriImageSource
        {
            Uri = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/FruitColors.jpg/800px-FruitColors.jpg"),
            CacheValidity = new TimeSpan(10, 0, 0, 0)
        };
    }
}
