using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using Mde.Storage.StorageBasics.Domain.Services;
using Mde.Storage.StorageBasics.Popups.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public class FileCachingViewModel : ObservableObject
    {
        private readonly IVideoService videoService;
        private MediaSource videoSource;

        public MediaSource VideoSource
        {
            get
            {
                return videoSource;
            }
            set
            {
                SetProperty(ref videoSource, value);
            }
        }
        public ICommand OnAppearingCommand => new Command(async () => await InitializePage());
        public ICommand DownloadVideoCommand => new Command(async () => await DownloadVideo());

        public FileCachingViewModel(IVideoService videoService)
        {
            this.videoService = videoService;
            VideoSource = MediaSource.FromUri(Constants.VideoUrl);
        }

        private async Task InitializePage()
        {

        }

        private async Task DownloadVideo()
        {

            var popupService = new PopupService();
            await popupService.ShowPopupAsync<ConfirmPopupViewModel>();

            var fileIsCached = videoService.CheckIfCached(Constants.VideoUrl);

            //if (!fileIsCached)
            //{
            //    await videoService.DownloadVideo("BigBuckBunny_320x180.mp4", Constants.VideoUrl);
            //}
            //else
            //{
            //    //get from cache
            //}

            //always load from disk

        }
    }
}
