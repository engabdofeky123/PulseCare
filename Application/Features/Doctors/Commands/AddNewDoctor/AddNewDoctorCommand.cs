using Application.DTOs.Doctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Commands.AddNewDoctor
{
    public record AddNewDoctorCommand(DoctorDto dto) : IRequest<DoctorDto?>;
}
