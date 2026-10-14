using Application.DTOs.Doctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    public record UpdateDoctorCommand(int id, DoctorDto dto) : IRequest<DoctorDto>;
}
