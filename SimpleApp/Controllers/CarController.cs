using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.BusinessLogicLayer.Car.Command;
using SimpleApp.BusinessLogicLayer.Queries;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CarController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpPost]
        [Route("admin/create-car")]
        public async Task<ActionResult<AddCarCommandResult>> CreateCarAsync([FromBody]CarDto request)
        {
            var command = new AddCarCommand
            {
                Brand = request.Brand,
                Mileage = request.Mileage,
                Model = request.Model,
                ProductionDate = request.ProductionDate
            };
            var result = await _mediatr.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("cars")]
        public async Task<ActionResult<List<CarDto>>> GetCars()
        {
            var query = new GetCarsQuery();

            var result = await _mediatr.Send(query);

            return Ok(result.Cars);
        }
    }
}