using Application.DTOs.Authentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Authentication.RefreshToken
{
    public record RefreshTokenCommand(string token) : IRequest<AuthModel>;
}
