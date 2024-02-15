using Mde.Storage.StorageBasics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Services
{
    public class AppPackageWalkthroughService : IWalkthroughService
    {
        JsonSerializerOptions serializationOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public async Task<IEnumerable<FlashCard>> GetDemoFlashCards()
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("Walkthrough/demodata.json");
            using StreamReader reader = new StreamReader(fileStream); 

            string json = await reader.ReadToEndAsync();
            
            return JsonSerializer.Deserialize<List<FlashCard>>(json, serializationOptions);
        }

    }
}
