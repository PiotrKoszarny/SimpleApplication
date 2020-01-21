using MediatR;
using Microsoft.AspNetCore.Hosting;
using SimpleApp.BusinessLogicLayer.Car.Command;
using SimpleApp.BusinessLogicLayer.Queries;
using SimpleApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BusinessLogicLayer.Services
{
    public interface ICarService
    {
        Task<AddCarCommandResult> AddCarAsync(AddCarDto car);
        Task<GetCarDetailsDto> GetCarAsync(int id);
        Task<List<GetCarDto>> GetCarsAsync();
    }

    public class CarService : ICarService
    {
        private readonly IMediator _mediator;
        private readonly IFileService _fileService;

        public CarService(
            IMediator mediator,
            IFileService fileService)
        {
            _mediator = mediator;
            _fileService = fileService;
        }

        public async Task<AddCarCommandResult> AddCarAsync(AddCarDto car)
        {
            var command = new AddCarCommand
            {
                Brand = car.Brand,
                Mileage = car.Mileage,
                Model = car.Model,
                ProductionDate = car.ProductionDate,
                PhotoNames = car.Photos.Select(x => x.FileName).ToList()
            };
            var result = await _mediator.Send(command);

            _fileService.SavePhotos(
                car.Photos,
                result.CarId);

            return result;
        }

        public async Task<List<GetCarDto>> GetCarsAsync()
        {
            var query = new GetCarsQuery();

            return await _mediator.Send(query);
        }

        public async Task<GetCarDetailsDto> GetCarAsync(int id)
        {
            var query = new GetCarQuery(id);

            return await _mediator.Send(query);
        }
    }
}
