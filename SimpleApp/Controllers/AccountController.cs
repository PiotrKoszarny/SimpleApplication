using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.BusinessLogicLayer.Services;
using SimpleApp.BusinessLogicLayer.User;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public AccountController(
            IMediator mediator,
            IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Register([FromBody]RegisterViewModel registerViewModel)
        {
            var command = new RegisterUserCommand
            {
                Password = registerViewModel.Password,
                ConfirmPassword = registerViewModel.ConfirmPassword,
                Email = registerViewModel.Email
            };

            var result = await _mediator.Send<RegisterUserCommandResult>(command);
            return Ok(result.Result);
        }

        [HttpPost]
        [Route("sign-in")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResultDto>> SignIn([FromBody]UserLoginDto user)
        {
            var command = new LoginUserCommand
            {
                Email = user.Email,
                Password = user.Password
            };

            var loginResult =
                await _mediator.Send(command);

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
            return Ok(result);
        }
    }
}