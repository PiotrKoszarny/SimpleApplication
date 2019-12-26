using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess;
using SimpleApp.Infrastructure.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BusinessLogicLayer.Queries
{
    public class GetCarsQuery : IQuery
    {
    }

    public class GetCarsQueryResult : IQueryResult
    {
        public IEnumerable<GetCarsQueryResultItem> Cars { get; set; }
    }

    public class GetCarsQueryResultItem
    {

        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
    }

    public class GetCarsQueryHandler : IQueryHandler<GetCarsQuery, GetCarsQueryResult>
    {
        private readonly SimpleDbContext _dbContext;

        public GetCarsQueryHandler(SimpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetCarsQueryResult> HandleAsync(GetCarsQuery query)
        {
            var result = await _dbContext.Cars.Select(x => new GetCarsQueryResultItem
            {
                Brand = x.Brand,
                CarId = x.CarId,
                Mileage = x.Mileage,
                Model = x.Model,
                ProductionDate = x.ProductionDate
            }).ToListAsync();

            return new GetCarsQueryResult { Cars = result };
        }
    }
}
