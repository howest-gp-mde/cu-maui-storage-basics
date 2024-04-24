using Mde.Storage.StorageBasics.Core.Models;
using System.Text.Json;

namespace Mde.Storage.StorageBasics.Core.Services
{
    public class AppPackageCoffeeService : ICoffeeService
    {
        JsonSerializerOptions serializationOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public async Task<IEnumerable<Coffee>> GetCoffeesAsync()
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("Coffees/coffees.json");
            using StreamReader reader = new StreamReader(fileStream); 

            string json = await reader.ReadToEndAsync();
            
            return JsonSerializer.Deserialize<List<Coffee>>(json, serializationOptions);
        }

    }
}
