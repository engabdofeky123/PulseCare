using Application.DTOs.Doctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Queries.GetAllDoctorsBySpeciality
{
    public record GetAllDoctorsBySpecialityQuery(string speciality) : IRequest<List<DoctorDto>>;
}
