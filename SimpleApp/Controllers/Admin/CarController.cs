using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.BusinessLogicLayer.Car.Command;
using SimpleApp.Infrastructure.CQRS.Command;

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
        public async Task<ActionResult<AddCarCommandResult>> CreateCarAsync([FromBody]AddCarCommand request)
        {
            var result = await _commandDispatcher.ExecuteAsync<AddCarCommand, AddCarCommandResult>(request);
            return Ok(result);
        }
    }
}