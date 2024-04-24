using Mde.Storage.StorageBasics.Core.Models;

namespace Mde.Storage.StorageBasics.Core.Services
{
    public interface ICoffeeService
    {
        Task<IEnumerable<Coffee>> GetCoffeesAsync();
    }
}
