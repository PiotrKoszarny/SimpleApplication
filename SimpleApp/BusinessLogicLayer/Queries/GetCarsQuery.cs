using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApp.BusinessLogicLayer.Queries
{
    public class GetCarsQuery : IRequest<GetCarsQueryResult>
    {
    }

    public class GetCarsQueryResult
    {
        public IEnumerable<CarDto> Cars { get; set; }
    }


    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, GetCarsQueryResult>
    {
        private readonly SimpleDbContext _dbContext;

        public GetCarsQueryHandler(SimpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetCarsQueryResult> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Cars.Select(x => new CarDto
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
