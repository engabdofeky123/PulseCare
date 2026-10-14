using Application.DTOs.Authentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Authentication.LogIn
{
    public record LogInCommand(LoginDto dto) : IRequest<AuthModel>;
}
