using Microsoft.Extensions.Configuration;
using SimpleApp.BusinessLogicLayer.Car.Command;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BusinessLogicLayer.Services
{
    public class CarService
    {
        private readonly string _photosPath;
        private readonly ICommandDispatcher _commandDispatcher;

        public CarService(
            IConfiguration configuration,
            ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _photosPath = configuration.GetValue<string>("PhtotPath");
        }
    }
}
