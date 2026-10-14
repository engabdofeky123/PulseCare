using Application.DTOs.Authentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Authentication.Register
{
    public record RegisterCommand(RegisterDto dto) : IRequest<AuthModel>;
}
