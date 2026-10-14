using Application.DTOs.Doctors;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Doctors.Queries.GetAllDoctorsBySpeciality
{
    public sealed class GetAllDoctorsBySpecialityHandler : IRequestHandler<GetAllDoctorsBySpecialityQuery, List<DoctorDto>>
    {
        private readonly IDoctorsRepository _doctorsRepository;

        public GetAllDoctorsBySpecialityHandler(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public async Task<List<DoctorDto>> Handle(GetAllDoctorsBySpecialityQuery request, CancellationToken cancellationToken)
        {
            return await _doctorsRepository.GetAllDoctorsBySpeciality(request.speciality);
        }
    }
}