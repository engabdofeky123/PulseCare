using Application.DTOs.ClinicSchedules;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Commands.AddNewSchedule
{
    public sealed class AddNewScheduleHandler : IRequestHandler<AddNewScheduleCommand, ClinicScheduleDto?>
    {
        private readonly IClinicSchedulesRepository _clinicRepository;

        public AddNewScheduleHandler(IClinicSchedulesRepository repo)
        {
            _clinicRepository = repo;
        }

        public async Task<ClinicScheduleDto?> Handle(AddNewScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _clinicRepository.AddNewSchedule(request.dto);
            if (await _clinicRepository.SaveChanges())
                return result;
            return null;
        }
    }
}
