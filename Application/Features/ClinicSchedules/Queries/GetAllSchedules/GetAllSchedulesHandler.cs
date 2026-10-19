using Application.DTOs.ClinicSchedules;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Queries.GetAllSchedules
{
    public sealed class GetAllSchedulesHandler : IRequestHandler<GetAllSchedulesQuery, List<ClinicScheduleDto>>
    {
        private readonly IClinicSchedulesRepository _clinicRepository;

        public GetAllSchedulesHandler(IClinicSchedulesRepository repo)
        {
            _clinicRepository = repo;
        }

        public async Task<List<ClinicScheduleDto>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
        {
            return await _clinicRepository.GetAllSchedules();
        }
    }
}