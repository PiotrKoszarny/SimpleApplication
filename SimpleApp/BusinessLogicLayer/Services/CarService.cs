using MediatR;
using Microsoft.Extensions.Configuration;

namespace SimpleApp.BusinessLogicLayer.Services
{
    public class CarService
    {
        private readonly string _photosPath;
        private readonly IMediator _mediator;

        public CarService(
            IConfiguration configuration,
            IMediator mediator)
        {
            _photosPath = configuration.GetValue<string>("PhtotPath");
            _mediator = mediator;
        }
    }
}
