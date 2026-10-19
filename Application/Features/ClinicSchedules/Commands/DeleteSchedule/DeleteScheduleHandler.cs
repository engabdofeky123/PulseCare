using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ClinicSchedules.Commands.DeleteSchedule
{
    public sealed class DeleteScheduleHandler : IRequestHandler<DeleteScheduleCommand, bool>
    {
        private readonly IClinicSchedulesRepository _clinicRepository;

        public DeleteScheduleHandler(IClinicSchedulesRepository repo)
        {
            _clinicRepository = repo;
        }

        public async Task<bool> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _clinicRepository.DeleteSchedule(request.scheduleId);
            var isSaved = await _clinicRepository.SaveChanges();

            if (isSaved && result)
                return true;
            return false;
        }
    }
}
