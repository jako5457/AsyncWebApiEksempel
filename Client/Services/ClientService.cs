using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ClientService : IHostedService
    {
        private readonly ICarApiClient apiClient;

        public ClientService(ICarApiClient apiClient) 
        {
            this.apiClient = apiClient;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await foreach (var car in apiClient.GetCarsAsync())
            {
                Console.WriteLine($"{car.name}");
            } 
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
