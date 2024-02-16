using Mde.Storage.StorageBasics.Domain.Models;

namespace Mde.Storage.StorageBasics.Domain.Services
{
    public interface ICoffeeService
    {
        Task<IEnumerable<Coffee>> GetCoffees();
    }
}
