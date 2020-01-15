using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SimpleApp.DataAccess.Entity;

namespace SimpleApp.BusinessLogicLayer.User
{
    public class LoginUserCommand : IRequest<LoginUserCommandResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandResult
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public bool IsSucceeded { get; set; }
        public bool IsLocked { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResult>
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

        public async Task<LoginUserCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            if (appUser == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, request.Password, false, false);
            if (result.Succeeded)
            {
                return new LoginUserCommandResult
                {
                    Email = request.Email,
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
