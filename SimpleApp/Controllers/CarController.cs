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
            var result = await _carService.AddCarAsync(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("cars")]
        public async Task<ActionResult<List<GetCarDto>>> GetCars()
        {
            return Ok(await _carService.GetCarsAsync());
        }

        [HttpGet]
        [Route("car/{id}")]
        public async Task<ActionResult<GetCarDetailsDto>> GetCar(int id)
        {
            var result = await _carService.GetCarAsync(id);

            return Ok(result);
        }
    }
}