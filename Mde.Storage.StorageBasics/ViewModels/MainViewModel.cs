using CommunityToolkit.Mvvm.ComponentModel;
using Mde.Storage.StorageBasics.Domain.Services;
using Mde.Storage.StorageBasics.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ICommand NavigateToCoffeeListPageCommand => new Command(async () => await NavigateToCoffeeListPage());
        public ICommand NavigateToBrewPageCommand => new Command(async () => await NavigateToBrewPage());
        public ICommand NavigateToCachingPageCommand => new Command(async () => await NavigateToCachingPage());
        public async Task NavigateToCoffeeListPage()
        {
            await Shell.Current.GoToAsync(nameof(CoffeeListPage));
        }

        public async Task NavigateToBrewPage()
        {
            await Shell.Current.GoToAsync(nameof(BrewPage));
        }        
        
        public async Task NavigateToCachingPage()
        {
            await Shell.Current.GoToAsync(nameof(ImageCachingPage));
        }
    }
}
