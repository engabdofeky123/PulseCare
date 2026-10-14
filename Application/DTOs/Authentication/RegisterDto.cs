using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Authentication
{
    public class RegisterDto
    {
        public string EmailOrUsername { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
