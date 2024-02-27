using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Services
{
    public interface IVideoService
    {
        Task DownloadVideo();
        bool VideoIsCached();
        string GetCachedVideoPath();
    }
}
