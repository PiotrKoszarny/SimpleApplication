using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.BusinessLogicLayer.Queries;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Infrastructure.CQRS.Query;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ProductController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IEnumerable<CarDto>> GetOffers()
        {
            var query = new GetCarsQuery();
            var result = await _queryDispatcher.ExecuteAsync<GetCarsQuery, GetCarsQueryResult>(query);

            return result.Cars.Select(x => new CarDto
            {
                Brand = x.Brand,
                CarId = x.CarId,
                Mileage = x.Mileage,
                Model = x.Model,
                ProductionDate = x.ProductionDate
            });
        }
    }
}