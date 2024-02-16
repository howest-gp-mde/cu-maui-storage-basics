using Mde.Storage.StorageBasics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Services
{
    public class AppPackageCoffeeService : ICoffeeService
    {
        JsonSerializerOptions serializationOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public async Task<IEnumerable<Coffee>> GetCoffees()
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("Coffees/coffees.json");
            using StreamReader reader = new StreamReader(fileStream); 

            string json = await reader.ReadToEndAsync();
            
            return JsonSerializer.Deserialize<List<Coffee>>(json, serializationOptions);
        }

    }
}
