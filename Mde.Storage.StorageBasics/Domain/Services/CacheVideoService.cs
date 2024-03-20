namespace Mde.Storage.StorageBasics.Domain.Services
{
    public class CacheVideoService : IVideoService
    {
        private static readonly string cacheDir = FileSystem.Current.CacheDirectory;

        public bool VideoIsCached()
        {
            var allFiles = Directory
                .EnumerateFiles(cacheDir)
                .Select(Path.GetFileName);

            bool isCached = allFiles.Contains(Constants.VideoFile);

            return isCached;
        }

        public async Task DownloadVideo()
        {
            HttpClient httpClient = new HttpClient();

            // Wikimedia explicity expects us to set the UserAgent header in our HTTP Requests in order to send back data
            // https://meta.wikimedia.org/wiki/User-Agent_policy
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("StorageBasicsDemoApp"); 

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
