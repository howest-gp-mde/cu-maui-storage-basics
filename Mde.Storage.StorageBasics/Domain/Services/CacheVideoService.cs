using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Services
{
    public class CacheVideoService : IVideoService
    {
        private static string CacheDir = FileSystem.Current.CacheDirectory;

        public bool CheckIfCached(string filename)
        {
            //todo
            return false;
        }

        public async Task DownloadVideo(string filename, string url)
        {
            HttpClient httpClient = new HttpClient();
            using (var stream = await httpClient.GetStreamAsync(url))
            {
                var filePath = Path.Combine(CacheDir, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }

        public MediaSource GetMediaSource(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
