using Application.DTOs.ClinicSchedules;
using Application.Features.ClinicSchedules.Commands.AddNewSchedule;
using Application.Features.ClinicSchedules.Commands.DeleteSchedule;
using Application.Features.ClinicSchedules.Commands.UpdateSchedule;
using Application.Features.ClinicSchedules.Queries.GetAllSchedules;
using Application.Features.ClinicSchedules.Queries.GetSchedule;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicSchedulesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClinicSchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("index")]
        public async Task<IActionResult> GetAllSchedules()
        {
            var result = await _mediator.Send(new GetAllSchedulesQuery());
            if (result.Count() == 0)
                return NotFound("There aren't any schedules");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedule([FromQuery] int? scheduleId, [FromQuery] int? doctorId)
        {
            var result = await _mediator.Send(new GetScheduleQuery(scheduleId, doctorId));
            if (result == null)
                return NotFound("Can't find the clinic schedule");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ClinicScheduleDto dto)
        {
            var result = await _mediator.Send(new AddNewScheduleCommand(dto));
            if (result == null)
                return NotFound("Can't add the clinic schedule");
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSchedule(int scheduleId, int doctorId, ClinicScheduleDto updatedScheduleDto)
        {
            var result = await _mediator.Send(new UpdateSCheduleCommand(scheduleId, doctorId, updatedScheduleDto));
            if (result == null)
                return NotFound("could not update the schedule");
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchedule(int scheduleId)
        {
            var result = await _mediator.Send(new DeleteScheduleCommand(scheduleId));
            if (!result)
                return NotFound("cold not delete the schedule");
            return NoContent();
        }
    }
}
