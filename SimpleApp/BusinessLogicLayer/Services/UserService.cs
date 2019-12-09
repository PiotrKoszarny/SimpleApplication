using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleApp.Settings;

namespace SimpleApp.BusinessLogicLayer.Services
{
    public interface IUserService
    {
        string GenerateToken(string userEmail);
    }

    public class UserService : IUserService
    {
        private readonly IOptions<AppSettings> _appOptions;

        public UserService(IOptions<AppSettings> appOptions)
        {
            _appOptions = appOptions;
        }

        public string GenerateToken(string userEmail)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appOptions.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userEmail), 
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
