using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.BusinessLogicLayer.Car.Command;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Models;

namespace SimpleApp.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CarController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Route("create-car")]
        public async Task<ActionResult<AddCarCommandResult>> CreateCarAsync([FromBody]CarDto request)
        {
            foreach (var item in request.Photos)
            {
                System.IO.File.WriteAllBytes(item.FileName, item.Value); 
            }

            var command = new AddCarCommand
            {
                Brand = request.Brand,
                Mileage = request.Mileage,
                Model = request.Model,
                ProductionDate = request.ProductionDate
            };
            var result = await _commandDispatcher.ExecuteAsync<AddCarCommand, AddCarCommandResult>(command);
            return Ok(result);
        }
    }
}