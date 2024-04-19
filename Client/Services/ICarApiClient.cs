using Shared.Models;

namespace Client.Services
{
    public interface ICarApiClient
    {
        IAsyncEnumerable<Car> GetCarsAsync();
    }
}