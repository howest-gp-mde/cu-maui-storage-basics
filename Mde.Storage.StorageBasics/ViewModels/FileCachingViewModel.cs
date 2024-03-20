﻿using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Mde.Storage.StorageBasics.Domain.Services;
using Mde.Storage.StorageBasics.Messages;
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
        private readonly IPopupService popupService;
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

        public FileCachingViewModel(IVideoService videoService, IPopupService popupService)
        {
            this.videoService = videoService;
            this.popupService = popupService;

            WeakReferenceMessenger.Default.Register<PopupMessage>(this, async (recipient, popupMessage) =>
            {
                if (popupMessage.Value == "yes")
                {
                    await videoService.DownloadVideo();
                    VideoSource = MediaSource.FromFile(videoService.GetCachedVideoPath());
                }
                else if (popupMessage.Value == "no")
                {
                    VideoSource = MediaSource.FromUri(Constants.VideoUrl);
                }

                WeakReferenceMessenger.Default.Unregister<PopupMessage>(this);

            });
        }

        private async Task InitializePage()
        {
            if (!videoService.VideoIsCached())
            {
                await popupService.ShowPopupAsync<ConfirmPopupViewModel>();
            }
            else
            {
                VideoSource = MediaSource.FromFile(videoService.GetCachedVideoPath());
            }
        }
    }
}
