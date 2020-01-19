using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.BusinessLogicLayer.Car.Command;
using SimpleApp.BusinessLogicLayer.Queries;
using SimpleApp.BusinessLogicLayer.Services;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly ICarService _carService;

        public CarController(
            IMediator mediatr,
            ICarService carService)
        {
            _mediatr = mediatr;
            _carService = carService;
        }


        [HttpPost]
        [Route("admin/create-car")]
        public async Task<ActionResult<AddCarCommandResult>> CreateCarAsync([FromBody]AddCarDto request)
        {
            var result = await _carService.AddCar(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("cars")]
        public async Task<ActionResult<List<AddCarDto>>> GetCars()
        {
            var query = new GetCarsQuery();

            var result = await _mediatr.Send(query);

            return Ok(result);
        }
    }
}