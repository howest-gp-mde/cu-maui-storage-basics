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
            if (popupMessage.Value == "yes")
            {

            }
            else if(popupMessage.Value == "no")
            {

            }

            //always close
            this.Close();
        });
    }
 }