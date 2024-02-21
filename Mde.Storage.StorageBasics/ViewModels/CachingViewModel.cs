using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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

        public ICommand RefreshCommand => new Command(() => {
            IsRefreshing = true;

            CachedImageSource = new UriImageSource
            {
                Uri = new Uri("https://picsum.photos/200/200"),
                //Uri = new Uri("https://cdn.pixabay.com/photo/2024/02/16/15/36/recipe-8577854_1280.jpg"),
                CachingEnabled = true, //default
                CacheValidity = TimeSpan.FromSeconds(30)
            };

            IsRefreshing = false;
        } );
    }
}
