using CommunityToolkit.Mvvm.ComponentModel;
using Mde.Storage.StorageBasics.Domain.Models;
using Mde.Storage.StorageBasics.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ICommand OnAppearingCommand => new Command(async () => await Refresh());
        public CoffeeListViewModel(ICoffeeService coffeeService)
        {
            this.coffeeService = coffeeService;
        }

        public async Task Refresh()
        {
            var coffees = await coffeeService.GetCoffees();
            Coffees = new ObservableCollection<Coffee>(coffees);
        }
    }
}
