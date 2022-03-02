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
            var sql = new SqlConnector();
            var cars = sql.ReadCarData(); // returns a list of cars
            return cars;
        }

        //[HttpGet(Name = "GetFirstCar")]
        [HttpGet]
        [Route("[controller]/[action]")]
        public Car GetFirstCar()
        {
            SqlConnector sql = new SqlConnector();
            Car firstcar = sql.ReadCarData().OrderBy(x => x.Name).First(); // first gives only 1 Car object
            return firstcar;
        }

    }
}