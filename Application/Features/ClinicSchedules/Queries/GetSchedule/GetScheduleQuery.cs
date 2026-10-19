using Application.DTOs.ClinicSchedules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Queries.GetSchedule
{
    public record GetScheduleQuery(int? scheduleId, int? doctorId) : IRequest<ClinicScheduleDto>;
}
