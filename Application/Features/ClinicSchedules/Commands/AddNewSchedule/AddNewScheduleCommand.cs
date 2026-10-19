using Application.DTOs.ClinicSchedules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Commands.AddNewSchedule
{
    public record AddNewScheduleCommand(ClinicScheduleDto dto) : IRequest<ClinicScheduleDto>;
}
