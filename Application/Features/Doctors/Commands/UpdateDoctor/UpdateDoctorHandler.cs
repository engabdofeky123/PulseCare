using Application.DTOs.Doctors;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    public sealed class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommand, DoctorDto?>
    {
        private readonly IDoctorsRepository _doctorsRepository;

        public UpdateDoctorHandler(IDoctorsRepository repo)
        {
            _doctorsRepository = repo;
        }

        public async Task<DoctorDto?> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var result = await _doctorsRepository.UpdateDoctor(request.id, request.dto);
            var saved = await _doctorsRepository.SaveChanges();

            if (!saved)
                return null;
            return result;
        }
    }
}
