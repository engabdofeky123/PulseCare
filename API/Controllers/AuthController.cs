using Application.DTOs.Authentication;
using Application.Features.Authentication.LogIn;
using Application.Features.Authentication.RefreshToken;
using Application.Features.Authentication.Register;
using Application.Features.Authentication.RevokeToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var command = new RegisterCommand(dto);
            var result = await _mediator.Send(command);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var command = new LogInCommand(dto);
            var result = await _mediator.Send(command);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpGet("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshToken))
                return BadRequest("Invalid Token");

            var result = await _mediator.Send(new RefreshTokenCommand(refreshToken));

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync([FromBody] RevokeTokenDto dto)
        {
            var token = dto.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("token is required");

            var result = await _mediator.Send(new RevokeTokenCommand(token));

            if (!result)
                return BadRequest("Token is Invalid");
            return Ok();
        }

        private void SetRefreshTokenInCookie(string token, DateTime expiresOn)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expiresOn
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);

        }
    }
}
