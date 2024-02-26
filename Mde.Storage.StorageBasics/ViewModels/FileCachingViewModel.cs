using Mde.Storage.StorageBasics.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public class FileCachingViewModel
    {
        private readonly IVideoService videoService;

        public ICommand DownloadVideoCommand => new Command(async () => await DownloadVideo());

        public FileCachingViewModel(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        private async Task DownloadVideo()
        {
            var fileIsCached = videoService.CheckIfCached(Constants.VideoUrl);

            if (!fileIsCached)
            {
                await videoService.DownloadVideo("BigBuckBunny_320x180.mp4", Constants.VideoUrl);
            }
            else
            {
                //get from cache
            }
        }
    }
}
