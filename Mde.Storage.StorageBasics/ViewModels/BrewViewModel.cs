using CommunityToolkit.Mvvm.ComponentModel;
using Mde.Storage.StorageBasics.Domain.Models;
using Mde.Storage.StorageBasics.Domain.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public partial class BrewViewModel : ObservableObject
    {
        private ICoffeeService coffeeService;
        private ICoffeeLoggingService coffeeLoggingService;

        private Coffee selectedCoffee;
        public Coffee SelectedCoffee
        {
            get { return selectedCoffee; }
            set { SetProperty(ref selectedCoffee, value); }
        }

        private ObservableCollection<Coffee> coffees;
        public ObservableCollection<Coffee> Coffees
        {
            get { return coffees; }
            set { SetProperty(ref coffees, value); }
        }

        private ObservableCollection<LogEntry> logs;
        public ObservableCollection<LogEntry> Logs
        {
            get { return logs; }
            set { SetProperty(ref logs, value); }
        }

        public ICommand OnAppearingCommand => new Command(async () => await Refresh());
        public ICommand BrewCommand => new Command(async ()  => await Brew());
        public ICommand ClearLogCommand => new Command(async ()  => await ClearLog());
        public BrewViewModel(ICoffeeService coffeeService, ICoffeeLoggingService coffeeLoggingService)
        {
            this.coffeeService = coffeeService;
            this.coffeeLoggingService = coffeeLoggingService;
        }

        public async Task Refresh()
        {
            if (Coffees is null)
            {
                var coffees = await coffeeService.GetCoffees();
                Coffees = new ObservableCollection<Coffee>(coffees);
                SelectedCoffee = Coffees[0];
            }

            var logs = coffeeLoggingService.GetLogs();            
            Logs = new ObservableCollection<LogEntry>(logs);
        }

        public async Task Brew()
        {
            coffeeLoggingService.Log(SelectedCoffee);
            await Refresh();
        }

        public async Task ClearLog()
        {
            coffeeLoggingService.Clear();
            await Refresh();
        }
    }
}
