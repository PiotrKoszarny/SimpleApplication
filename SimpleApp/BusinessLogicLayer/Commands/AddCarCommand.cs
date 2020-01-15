using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using SimpleApp.DataAccess;
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
        public IEnumerable<ImgFileDto> Photos { get; set; }
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
        private readonly string _photosPath;

        public AddCarCommanHandler(
            SimpleDbContext dbContext,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _photosPath = configuration.GetValue<string>("PhotoPath");

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

            //car.FilePath = $@"{_photosPath}/{car.CarId}";


            //foreach (var item in request.Photos)
            //{
            //    System.IO.File.WriteAllBytes(car.FilePath, item.Value);
            //}

            await _dbContext.SaveChangesAsync();

            return new AddCarCommandResult
            {
                Mileage = car.Mileage,
                Model = car.Model,
                ProductionDate = car.ProductionDate,
                Brand = car.Brand,
                CarId = car.CarId
            };
        }
    }
}
