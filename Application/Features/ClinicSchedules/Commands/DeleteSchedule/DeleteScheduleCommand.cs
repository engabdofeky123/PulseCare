using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Commands.DeleteSchedule
{
    public record DeleteScheduleCommand(int scheduleId) : IRequest<bool>;
}
