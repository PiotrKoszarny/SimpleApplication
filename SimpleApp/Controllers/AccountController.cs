using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.BusinessLogicLayer.Services;
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
        private readonly IUserService _userService;

        public AccountController(
            ICommandDispatcher commandDispatcher,
            IUserService userService
                )
        {
            _commandDispatcher = commandDispatcher;
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Register(RegisterViewModel registerViewModel)
        {
            var command = new RegisterUserCommand
            {
                Password = registerViewModel.Password,
                ConfirmPassword = registerViewModel.ConfirmPassword,
                Email = registerViewModel.Email
            };

            var result = await _commandDispatcher.ExecuteAsync<RegisterUserCommand, RegisterUserCommandResult>(command);
            return Ok(result.Result);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResultDto>> Login(UserLoginDto user)
        {
            var command = new LoginUserCommand
            {
                Email = user.Email,
                Password = user.Password
            };

            var loginResult =
                await _commandDispatcher.ExecuteAsync<LoginUserCommand, LoginUserCommandResult>(command);

            var result = new UserLoginResultDto
            {
                Email = loginResult.Email,
                UserId = loginResult.UserId,
                IsSuccessed = loginResult.IsSucceeded,
                IsLocked = loginResult.IsLocked
            };

            if (!loginResult.IsSucceeded || loginResult.IsLocked) 
            {
                return result;
            }

            result.Token = _userService.GenerateToken(loginResult.Email);
            return result;

        }
    }
}