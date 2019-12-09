using System.ComponentModel.DataAnnotations;

namespace SimpleApp.Models
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginResultDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool IsSuccessed { get; set; }
        public string LoginError { get; set; }
        public string Token { get; set; }
    }
}
