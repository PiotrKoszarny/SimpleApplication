using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using SimpleApp.DataAccess;
using SimpleApp.DataAccess.Entity;
using SimpleApp.Models;

namespace SimpleApp.BusinessLogicLayer.Car.Command
{
    public class AddCarCommand : IRequest<AddCarCommandResult>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
        public string CarPhotoPath { get; set; }
        public byte[] CarPhoto { get; set; }
        public List<string> PhotoNames { get; set; }
    }

    public class AddCarCommandResult
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
    }

    public class AddCarCommanHandler : IRequestHandler<AddCarCommand, AddCarCommandResult>
    {
        private readonly SimpleDbContext _dbContext;

        public AddCarCommanHandler(
            SimpleDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<AddCarCommandResult> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var car = new DataAccess.Entity.Car
            {
                Brand = request.Brand,
                Mileage = request.Mileage,
                Model = request.Model,
                ProductionDate = request.ProductionDate
            };

            await _dbContext.AddAsync(car);

            var photos = request.PhotoNames.Select(name => new Photo
            {
                Car = car,
                FileName = name
            });
            await _dbContext.AddRangeAsync(photos);

            await _dbContext.SaveChangesAsync();

            return new AddCarCommandResult
            {
                Mileage = car.Mileage,
                Model = car.Model,
                ProductionDate = car.ProductionDate,
                Brand = car.Brand,
                CarId = car.Id
            };
        }
    }
}
