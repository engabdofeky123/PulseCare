using Application.DTOs.Authentication;
using Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Authentication.LogIn
{
    public sealed class LogInHandler : IRequestHandler<LogInCommand, AuthModel>
    {
        private readonly IAuthService _authService;

        public LogInHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthModel> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request.dto);
        }
    }
}
