using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Commands.DeleteDoctor
{
    public record DeleteDoctorCommand(int id) : IRequest<bool>;
}
