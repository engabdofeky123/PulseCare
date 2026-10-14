using Application.DTOs.Authentication;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterDto model);
        
        Task<AuthModel> LoginAsync(LoginDto model);

        Task<AuthModel> RefreshTokenAsync(string token);

        Task<bool> RevokeToken(string token);
    }
}
