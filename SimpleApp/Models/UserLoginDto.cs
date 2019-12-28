using System;

namespace SimpleApp.Models
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginResultDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public bool IsSuccessed { get; set; }
        public bool IsLocked { get; set; }
        public string LoginError { get; set; }
        public string Token { get; set; }
    }
}
