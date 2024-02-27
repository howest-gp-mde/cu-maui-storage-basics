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
        private static readonly string cacheDir = FileSystem.Current.CacheDirectory;

        public bool VideoIsCached()
        {
            List<string> allFiles = Directory
                .EnumerateFiles(cacheDir)
                .Select(Path.GetFileName)
                .ToList();

            bool isCached = allFiles.Contains(Constants.VideoFile);

            return isCached;
        }

        public async Task DownloadVideo()
        {
            HttpClient httpClient = new HttpClient();
            using (var stream = await httpClient.GetStreamAsync(Constants.VideoUrl))
            {
                var filePath = Path.Combine(cacheDir, Constants.VideoFile);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }

        public string GetCachedVideoPath()
        {
            return Path.Combine(cacheDir, Constants.VideoFile);
        }
    }
}
