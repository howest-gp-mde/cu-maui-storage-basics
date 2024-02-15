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
        public ICommand NavigateToWalkThroughPageCommand => new Command(async () => await NavigateToWalkTroughPage());
        public async Task NavigateToWalkTroughPage()
        {
            await Shell.Current.GoToAsync(nameof(WalkthroughPage));
        }
    }
}
