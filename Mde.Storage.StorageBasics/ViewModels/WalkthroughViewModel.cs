using CommunityToolkit.Mvvm.ComponentModel;
using Mde.Storage.StorageBasics.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public partial class WalkthroughViewModel : ObservableObject
    {
        private IWalkthroughService walkthroughService;
        public ICommand OnAppearing => new Command(async () => await Refresh());
        public WalkthroughViewModel(IWalkthroughService walkthroughService)
        {
            this.walkthroughService = walkthroughService;
        }

        public async Task Refresh()
        {
            var test = await walkthroughService.GetDemoFlashCards();
        }
    }
}
