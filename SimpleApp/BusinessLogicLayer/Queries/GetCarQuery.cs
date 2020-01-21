using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess;
using SimpleApp.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApp.BusinessLogicLayer.Queries
{
    public class GetCarQuery : IRequest<GetCarDetailsDto>
    {
        public GetCarQuery(int carId)
        {
            CarId = carId;
        }

        public int CarId { get; }
    }

    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, GetCarDetailsDto>
    {
        private readonly SimpleDbContext _dbContext;

        public GetCarQueryHandler(SimpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetCarDetailsDto> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            return await (from c in _dbContext.Cars
                          where c.Id == request.CarId
                          select new GetCarDetailsDto
                          {
                              Brand = c.Brand,
                              CarId = c.Id,
                              Model = c.Model,
                              Mileage = c.Mileage,
                              ProductionDate = c.ProductionDate,
                              PhotoUrls = c.Photos.Select(x => x.FileName).ToList()
                          }).FirstOrDefaultAsync();
        }
    }
}
