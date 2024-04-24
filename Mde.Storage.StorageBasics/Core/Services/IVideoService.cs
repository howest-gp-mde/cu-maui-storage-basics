namespace Mde.Storage.StorageBasics.Core.Services
{
    public interface IVideoService
    {
        Task DownloadVideoAsync();
        bool VideoIsCached();
        string GetCachedVideoPath();
    }
}
