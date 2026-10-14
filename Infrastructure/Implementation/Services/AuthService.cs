using Application.DTOs.Authentication;
using Application.Interfaces.Services;
using Infrastructure.Helpers;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtHelper _jwtHelper;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtHelper helper)
        {
            _userManager = userManager;
            _jwtHelper = helper;
        }

        public async Task<AuthModel> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.EmailOrUsername)?? await _userManager.FindByNameAsync(model.EmailOrUsername);
            if (user == null)
                return new AuthModel { Message = "Email or username is not registered" };

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return new AuthModel { Message = "Invalid email or password" };

            var authModel = new AuthModel()
            {
                IsAuthenticated = true,
                Email = user.Email,
                Username = user.UserName,
                Roles = (await _userManager.GetRolesAsync(user)).ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(await GenerateToken(user)),
                Message = "Login successful",
                Expiration = DateTime.UtcNow.AddDays(_jwtHelper.ExpirationInDays)
            };

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken = activeRefreshToken?.Token;
                authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
                return authModel;
            }
            else
            {
                var refreshToken = await GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            return authModel;
        }

        public async Task<AuthModel> RegisterAsync(RegisterDto model)
        {
            if(await _userManager.FindByEmailAsync(model.EmailOrUsername) != null || await _userManager.FindByNameAsync(model.EmailOrUsername) != null)
                return new AuthModel { Message = "Email or username is already registered" };

            var newUser = new ApplicationUser
            {
                UserName = model.EmailOrUsername,
                Email = model.EmailOrUsername
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new AuthModel { Message = $"User creation failed: {errors}" };
            }

            await _userManager.AddToRolesAsync(newUser, new List<string> { model.Role });
            var jwtToken = await GenerateToken(newUser);

            return new AuthModel
            {
                Email = newUser.Email,
                Username = newUser.UserName,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expiration = jwtToken.ValidTo,
                Roles = await _userManager.GetRolesAsync(newUser) as List<string>
            };
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user) 
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesClaims = roles.Select(role => new Claim("role", role)).ToList();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            }
            .Union(rolesClaims)
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtHelper.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtHelper.Issuer,
                audience: _jwtHelper.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_jwtHelper.ExpirationInDays),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;

        }

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel = new AuthModel();
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
            {
                authModel.IsAuthenticated = false;
                authModel.Message = "Invalid Token";
                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                authModel.IsAuthenticated = false;
                authModel.Message = "Inactive Token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;
            var newRefreshToken = await GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                authModel.IsAuthenticated = false;
                authModel.Message = "Failed to update token";
                return authModel;
            }

            var jwt = await GenerateToken(user);
            authModel.IsAuthenticated = true;
            authModel.Message = "Successfully";
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.Roles = (await _userManager.GetRolesAsync(user)).ToList();
            authModel.Token =new JwtSecurityTokenHandler().WriteToken(jwt);
            authModel.RefreshToken = newRefreshToken.Token;
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return authModel;
        }

        public async Task<bool> RevokeToken(string token)
        {
            var authModel = new AuthModel();
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;
            var newRefreshToken = await GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            var result = await _userManager.UpdateAsync(user);

            return true;
        }

        private async Task<RefreshToken> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var generator = new RNGCryptoServiceProvider();

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }
    }
}