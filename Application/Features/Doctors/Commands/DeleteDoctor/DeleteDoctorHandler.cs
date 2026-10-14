using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Doctors.Commands.DeleteDoctor
{
    public sealed class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, bool>
    {
        private readonly IDoctorsRepository _doctorssRepository;

        public DeleteDoctorHandler(IDoctorsRepository repo)
        {
            _doctorssRepository = repo;
        }

        public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var result = await _doctorssRepository.DeleteDoctor(request.id);
            var saved = await _doctorssRepository.SaveChanges();

            if (saved)
                return true;
            return false;
        }
    }
}
