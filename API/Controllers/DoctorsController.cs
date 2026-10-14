using Application.DTOs.Doctors;
using Application.Features.Doctors.Commands.AddNewDoctor;
using Application.Features.Doctors.Commands.DeleteDoctor;
using Application.Features.Doctors.Commands.UpdateDoctor;
using Application.Features.Doctors.Queries.GetAllDoctors;
using Application.Features.Doctors.Queries.GetAllDoctorsBySpeciality;
using Application.Features.Doctors.Queries.GetDoctorById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _mediator.Send(new GetAllDoctorsQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDoctorById([FromQuery]int id)
        {
            var query = new GetDoctorByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound($"Could not find doctor with ID:{id}");
            return Ok(result);
        }

        [HttpGet("/{speciality:alpha}")]
        public async Task<IActionResult> GetAllDoctorsBySpeciality(string speciality)
        {
            return Ok(await _mediator.Send(new GetAllDoctorsBySpecialityQuery(speciality)));
        }

        [HttpPost("add-new-doctor")]
        public async Task<IActionResult> AddNewDoctor(DoctorDto dto)
        {
            var result = await _mediator.Send(new AddNewDoctorCommand(dto));
            if (result == null)
                return NotFound("Can't create a new doctor");
            return Ok(result);
        }

        [HttpPut("update-doctor/{id:int}")]
        public async Task<IActionResult> UpdateDoctor([FromQuery] int id , [FromBody] DoctorDto dto )
        {
            var result = await _mediator.Send(new UpdateDoctorCommand(id, dto));
            if (result == null)
                return NotFound("Can't update this doctor");
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _mediator.Send(new DeleteDoctorCommand(id));
            if (!result)
                return NotFound("Can't delete this doctor");
            return Ok("deleted successfully");
        }

    }
}
