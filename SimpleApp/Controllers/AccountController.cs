using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.BusinessLogicLayer.User;
using SimpleApp.DataAccess.Entity;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AccountController(
            ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var registerCommand = new RegisterUserCommand
            {
                Password = registerViewModel.Password,
                ConfirmPassword = registerViewModel.ConfirmPassword,
                Email = registerViewModel.Email
            };

            var result = await _commandDispatcher.Execute<RegisterUserCommand, RegisterUserCommandResult>(registerCommand);
            return Ok(result);
        }
    }
}