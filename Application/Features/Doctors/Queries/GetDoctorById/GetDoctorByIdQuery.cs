using Application.DTOs.Doctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Queries.GetDoctorById
{
    public record GetDoctorByIdQuery(int id) : IRequest<DoctorDto?>;
}
