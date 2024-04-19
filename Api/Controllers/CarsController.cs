using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Bogus;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(ILogger<CarsController> _Logger) : ControllerBase
    {



        [HttpGet]
        public async IAsyncEnumerable<Car> GetCarsAsync()
        {
            Faker<Car> carFaker = new Faker<Car>()
                                    .RuleFor(c => c.name,f => f.Vehicle.Manufacturer() + " " + f.Vehicle.Model())
                                    .RuleFor(c => c.MaxSpeed,f => Random.Shared.Next(50,200))
                                    .RuleFor(c => c.id,f => Random.Shared.Next(1,1000));

            int count = 1;
            foreach (Car item in carFaker.Generate(1000))
            {
                await Task.Delay(500);

                Console.Clear();
                Console.WriteLine($"Object {count} out of 1000");
                Console.WriteLine($"Sending: {item.name}");
                count++;

                yield return item;
            }
        }

    }
}
