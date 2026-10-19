using Application.DTOs.ClinicSchedules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Commands.UpdateSchedule
{
    public record UpdateSCheduleCommand(
        int scheduleId,
        int doctorId,
        ClinicScheduleDto updatedScheduleDto) : IRequest<ClinicScheduleDto?>;
}
