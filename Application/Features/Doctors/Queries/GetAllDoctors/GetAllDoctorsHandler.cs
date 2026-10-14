using Application.DTOs.Doctors;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Queries.GetAllDoctors
{
    public sealed class GetAllDoctorsHandler : IRequestHandler<GetAllDoctorsQuery, List<DoctorDto>>
    {
        private readonly IDoctorsRepository _doctorsRepository;

        public GetAllDoctorsHandler(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public async Task<List<DoctorDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            return await _doctorsRepository.GetAllDoctors();
        }
    }
}
