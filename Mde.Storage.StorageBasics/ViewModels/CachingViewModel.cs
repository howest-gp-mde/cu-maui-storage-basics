using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mde.Storage.StorageBasics.ViewModels
{
    public partial class CachingViewModel : ObservableObject
    {
        public string LastUpdate => DateTimeOffset.Now.ToLocalTime().ToString();

        private bool isRefreshing = false;
        public bool IsRefreshing 
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }

        private UriImageSource cachedImageSource = new UriImageSource
        {
            Uri = new Uri("https://picsum.photos/200/200"),
            CachingEnabled = true, //default
            CacheValidity = TimeSpan.FromSeconds(30)
        };
        public UriImageSource CachedImageSource 
        { 
            get { return  cachedImageSource; }
            set { SetProperty(ref cachedImageSource, value); }
        }

        private ObservableCollection<string> cachedFiles;

        public ObservableCollection<string> CachedFiles
        {
            get { return cachedFiles; }
            set { SetProperty(ref cachedFiles, value); }
        }

        public CachingViewModel()
        {
            DisplayCachedFiles();
        }


        public ICommand RefreshCommand => new Command(() => {
            IsRefreshing = true;

            CachedImageSource = new UriImageSource
            {
                Uri = new Uri("https://picsum.photos/200/200"),
                //Uri = new Uri("https://cdn.pixabay.com/photo/2024/02/16/15/36/recipe-8577854_1280.jpg"),
                CachingEnabled = true, //default
                CacheValidity = TimeSpan.FromSeconds(30)
            };

            DisplayCachedFiles();

            IsRefreshing = false;
        } );

        public void DisplayCachedFiles()
        {
            //WinUI does not cache images, prevent code from running on windows, iOS not tested yet ...
            if (DeviceInfo.Current.Platform != DevicePlatform.Android) 
            { 
                CachedFiles = null;
                return;
            };

            var path = FileSystem.CacheDirectory;

            //var contents = Directory.EnumerateFiles(path).ToList();
            var subdirs = Directory.EnumerateDirectories(path).ToList();

            if(subdirs.Count > 0 )
            {
                var imagecachedir = subdirs.FirstOrDefault(); // /data/user/0/com.companyname.mde.storage.storagebasics/cache/image_manager_disk_cache
                var imageCachePaths = Directory.GetFiles(imagecachedir).ToList();

                List<string> cachedImages = new List<string>();
                foreach (string fullPath in imageCachePaths)
                {
                    string filename = Path.GetFileName(fullPath);
                    cachedImages.Add(filename);
                }

                CachedFiles = new ObservableCollection<string>(cachedImages);
            }

        }
    }
}
