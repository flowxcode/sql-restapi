using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
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

        //[HttpGet(Name = "GetCars")]
        [HttpGet]
        [Route("[controller]/[action]")]
        public List<Car> GetCars()
        {
            SqlConnector sql = new SqlConnector();
            var cars = sql.ReadCarData();
            return cars;
        }

        //[HttpGet(Name = "GetFirstCar")]
        [HttpGet]
        [Route("[controller]/[action]")]
        public Car GetFirstCar()
        {
            SqlConnector sql = new SqlConnector();
            var car = sql.ReadCarData().OrderBy(x => x.Name).First();
            return car;
        }

    }
}