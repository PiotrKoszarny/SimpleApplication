using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess;
using SimpleApp.DataAccess.Entity;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApp.BusinessLogicLayer.Queries
{
    public class GetCarsQuery : IRequest<List<GetCarDto>>
    {
    }


    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<GetCarDto>>
    {
        private readonly SimpleDbContext _dbContext;

        public GetCarsQueryHandler(SimpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetCarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var result = await (from c in _dbContext.Cars
                                select new GetCarDto
                                {
                                    Brand = c.Brand,
                                    CarId = c.Id,
                                    Mileage = c.Mileage,
                                    Model = c.Model,
                                    ProductionDate = c.ProductionDate,
                                    PhotoUrls = c.Photos.Select(x=>x.FileName).ToList()
                                })
                                 .ToListAsync();
                

            return result;
        }
    }
}
