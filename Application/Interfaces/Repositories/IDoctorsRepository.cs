using Application.DTOs.Doctors;

namespace Application.Interfaces.Repositories
{
    public interface IDoctorsRepository
    {
        public Task<DoctorDto?> GetDoctorById(int id);
        public Task<List<DoctorDto>> GetAllDoctors();
        public Task<DoctorDto> AddNewDoctor(DoctorDto dto);
        public Task<List<DoctorDto>> GetAllDoctorsBySpeciality(string speciality);
        public Task<DoctorDto?> UpdateDoctor(int id,DoctorDto dto);
        public Task<bool> DeleteDoctor(int id);
        public Task<bool> SaveChanges();
    }
}