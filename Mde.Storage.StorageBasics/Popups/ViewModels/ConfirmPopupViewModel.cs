using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Mde.Storage.StorageBasics.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.Popups.ViewModels
{
    public class ConfirmPopupViewModel : ObservableObject
    {
        public ICommand OnYesCommand => new Command(() => { WeakReferenceMessenger.Default.Send(new PopupMessage("yes")); });
        public ICommand OnNoCommand => new Command(() => { WeakReferenceMessenger.Default.Send(new PopupMessage("no")); });
    }
}
