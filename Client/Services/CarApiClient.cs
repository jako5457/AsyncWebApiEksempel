using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    public class CarApiClient : ICarApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
      
        public async IAsyncEnumerable<Car> GetCarsAsync()
        {   
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "/api/cars");
            msg.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var client = _httpClientFactory.CreateClient("CarApi");
            var resp = await client.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead);


            var enumerable = JsonSerializer.DeserializeAsyncEnumerable<Car>(resp.Content.ReadAsStream());

            await foreach (var car in enumerable)
            {
                yield return car;
            }
        }

    }
}
