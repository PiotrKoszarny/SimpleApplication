using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleApp.DataAccess;
using SimpleApp.Infrastructure.CQRS.Command;

namespace SimpleApp.BusinessLogicLayer.Car.Command
{
    public class AddCarCommand : ICommand
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Mileage { get; set; }
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

        public AddCarCommanHandler(SimpleDbContext dbContext)
        {
            _dbContext = dbContext;
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
