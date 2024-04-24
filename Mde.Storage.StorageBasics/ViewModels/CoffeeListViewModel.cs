using CommunityToolkit.Mvvm.ComponentModel;
using Mde.Storage.StorageBasics.Core.Models;
using Mde.Storage.StorageBasics.Core.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public partial class CoffeeListViewModel : ObservableObject
    {
        private ICoffeeService coffeeService;

        private ObservableCollection<Coffee> coffees;

        public ObservableCollection<Coffee> Coffees
        {
            get { return coffees; }
            set { SetProperty(ref coffees, value); }
        }

        public ICommand OnAppearingCommand => new Command(async () => await RefreshAsync());
        public CoffeeListViewModel(ICoffeeService coffeeService)
        {
            this.coffeeService = coffeeService;
        }

        public async Task RefreshAsync()
        {
            var coffees = await coffeeService.GetCoffeesAsync();
            Coffees = new ObservableCollection<Coffee>(coffees);
        }
    }
}
