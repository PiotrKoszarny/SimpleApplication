using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleApp.DataAccess.Entity;
using SimpleApp.Infrastructure.CQRS.Command;

namespace SimpleApp.BusinessLogicLayer.User
{
    public class RegisterUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterUserCommandResult : ICommandResult
    {
        public bool Result { get; set; }
    }

    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegisterUserCommandResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterUserCommandResult> ExecuteAsync(RegisterUserCommand command)
        {
            var user = new ApplicationUser
            {
                Email = command.Email,
                UserName = command.Email
            };

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, command.Password);
            var result = await _userManager.CreateAsync(user);
            return new RegisterUserCommandResult { Result = result.Succeeded };
        }
    }
}
