using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Messages
{
    public class PopupMessage : ValueChangedMessage<string>
    {
        public PopupMessage(string message) : base(message)
        {
            
        }
    }
}
