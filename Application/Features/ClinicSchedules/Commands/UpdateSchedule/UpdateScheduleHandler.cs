using Application.DTOs.ClinicSchedules;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Commands.UpdateSchedule
{
    public sealed class UpdateScheduleHandler : IRequestHandler<UpdateSCheduleCommand, ClinicScheduleDto?>
    {
        private readonly IClinicSchedulesRepository _clinicRepository;

        public UpdateScheduleHandler(IClinicSchedulesRepository repo)
        {
            _clinicRepository = repo;
        }

        public async Task<ClinicScheduleDto?> Handle(UpdateSCheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _clinicRepository.UpdateSchedule(request.scheduleId, request.doctorId, request.updatedScheduleDto);
            if (await _clinicRepository.SaveChanges())
                return result;
            return null;
        }
    }
}
