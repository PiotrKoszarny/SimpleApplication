using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleApp.DataAccess.Entity;
using SimpleApp.Infrastructure.CQRS.Command;

namespace SimpleApp.BusinessLogicLayer.User
{
    public class LoginUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandResult : ICommandResult
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool IsSucceeded { get; set; }
        public bool IsLocked { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoginUserCommandResult>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginUserCommandHandler(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginUserCommandResult> ExecuteAsync(LoginUserCommand command)
        {
            var appUser = await _userManager.FindByEmailAsync(command.Email);
            if (appUser == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, command.Password, false, false);
            if (result.Succeeded)
            {
                return new LoginUserCommandResult
                {
                    Email = command.Email,
                    IsSucceeded = true,
                    UserId = appUser.Id
                };
            }

            if (result.IsLockedOut)
            {
                return new LoginUserCommandResult
                {
                    IsLocked = true
                };
            }

            return null;
        }
    }
}
