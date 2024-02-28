using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using Mde.Storage.StorageBasics.Messages;
using Mde.Storage.StorageBasics.Popups.ViewModels;

namespace Mde.Storage.StorageBasics.Popups.Views;

public partial class ConfirmPopup : Popup
{
    public ConfirmPopup(ConfirmPopupViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;

        WeakReferenceMessenger.Default.Register<PopupMessage>(this, (recipient, popupMessage) =>
        {
            //always close
            this.Close();

            //unregister again, because otherwise the old popup (this) would still be 'listening' while its object has already been disposed of!
            WeakReferenceMessenger.Default.Unregister<PopupMessage>(this);
        });
    }
 }