using Application.DTOs.Doctors;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Queries.GetDoctorById
{
    public sealed class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto?>
    {
        private readonly IDoctorsRepository _doctorsRepository;

        public GetDoctorByIdHandler(IDoctorsRepository doctorsRepo)
        {
            _doctorsRepository = doctorsRepo;
        }

        public async Task<DoctorDto?> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _doctorsRepository.GetDoctorById(request.id);   
        }
    }
}
