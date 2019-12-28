using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleApp.DataAccess;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Models;

namespace SimpleApp.BusinessLogicLayer.Car.Command
{
    public class AddCarCommand : ICommand
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
        public string CarPhotoPath { get; set; }
        public byte[] CarPhoto { get; set; }
        public IEnumerable<ImgFileDto> Photos { get; set; }
    }

    public class AddCarCommandResult : ICommandResult
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
    }

    public class AddCarCommanHandler : ICommandHandler<AddCarCommand, AddCarCommandResult>
    {
        private readonly SimpleDbContext _dbContext;
        private readonly string _photosPath;

        public AddCarCommanHandler(
            SimpleDbContext dbContext,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _photosPath = configuration.GetValue<string>("PhtotPath");

        }

        public async Task<AddCarCommandResult> ExecuteAsync(AddCarCommand command)
        {
            var car = new DataAccess.Entity.Car
            {
                Brand = command.Brand,
                Mileage = command.Mileage,
                Model = command.Model,
                ProductionDate = command.ProductionDate
            };

            await _dbContext.AddAsync(car);

            car.FilePath = $@"{_photosPath}/{car.CarId}";


            foreach (var item in command.Photos)
            {
                System.IO.File.WriteAllBytes(car.FilePath, item.Value);
            }

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
