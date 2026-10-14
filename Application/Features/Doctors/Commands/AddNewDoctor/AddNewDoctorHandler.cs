using Application.DTOs.Doctors;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Commands.AddNewDoctor
{
    public sealed class AddNewDoctorHandler : IRequestHandler<AddNewDoctorCommand, DoctorDto?>
    {
        private readonly IDoctorsRepository _doctorsRepository;

        public AddNewDoctorHandler(IDoctorsRepository repo)
        {
            _doctorsRepository = repo;
        }

        public async Task<DoctorDto?> Handle(AddNewDoctorCommand request, CancellationToken cancellationToken)
        {
            var result = await _doctorsRepository.AddNewDoctor(request.dto);
            var saved = await _doctorsRepository.SaveChanges();

            if (!saved)
                return null;
            return result;

        }
    }
}