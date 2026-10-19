using Application.DTOs.ClinicSchedules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IClinicSchedulesRepository
    {
        Task<List<ClinicScheduleDto>> GetAllSchedules(); 
       
        Task<ClinicScheduleDto?> GetSchedule(int? scheduleId = null, int? doctorId = null);
      
        Task<ClinicScheduleDto> AddNewSchedule( ClinicScheduleDto newScheduleDto);
      
        Task<ClinicScheduleDto?> UpdateSchedule(int scheduleId, int doctorId, ClinicScheduleDto updatedScheduleDto);
        
        Task<bool> DeleteSchedule(int scheduleId);

        public Task<bool> SaveChanges();
    }
}