using CommunityToolkit.Mvvm.ComponentModel;
using Mde.Storage.StorageBasics.Pages;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ICommand NavigateToCoffeeListPageCommand => new Command(async () => await NavigateToCoffeeListPageAsync());
        public ICommand NavigateToBrewPageCommand => new Command(async () => await NavigateToBrewPageAsync());
        public ICommand NavigateToImageCachingPageCommand => new Command(async () => await NavigateToImageCachingPageAsync());
        public ICommand NavigateToFileCachingPageCommand => new Command(async () => await NavigateToFileCachingPageAsync());
        public async Task NavigateToCoffeeListPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(CoffeeListPage));
        }

        public async Task NavigateToBrewPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(BrewPage));
        }        
        
        public async Task NavigateToImageCachingPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(ImageCachingPage));
        }

        public async Task NavigateToFileCachingPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(FileCachingPage));
        }
    }
}
