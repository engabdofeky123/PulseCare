using Application.DTOs.ClinicSchedules;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Queries.GetSchedule
{
    public sealed class GetScheduleHandler : IRequestHandler<GetScheduleQuery, ClinicScheduleDto?>
    {
        private readonly IClinicSchedulesRepository _clinicRepository;

        public GetScheduleHandler(IClinicSchedulesRepository repo)
        {
            _clinicRepository = repo;
        }

        public async Task<ClinicScheduleDto?> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
        {
            return await _clinicRepository.GetSchedule(request.scheduleId, request.doctorId);
        }
    }
}
