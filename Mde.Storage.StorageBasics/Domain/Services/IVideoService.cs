using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Services
{
    public interface IVideoService
    {
        Task DownloadVideo(string filename, string url);
        bool CheckIfCached(string filename);
    }
}
