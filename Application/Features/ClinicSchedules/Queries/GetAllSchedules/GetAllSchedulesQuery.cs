using Application.DTOs.ClinicSchedules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Queries.GetAllSchedules
{
    public record GetAllSchedulesQuery() : IRequest<List<ClinicScheduleDto>>;
}
