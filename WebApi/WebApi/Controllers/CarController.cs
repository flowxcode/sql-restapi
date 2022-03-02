using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCars")]
        public List<Car> Get()
        {
            SqlConnector sql = new SqlConnector();
            var cars = sql.ReadCarData();

            return cars;
        }

    }
}