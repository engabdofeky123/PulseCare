using Application.DTOs.ClinicSchedules;
using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories
{
    public class ClinicSchedulesRepository : IClinicSchedulesRepository
    {
        private readonly ApplicationDbContext _context;

        public ClinicSchedulesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClinicScheduleDto> AddNewSchedule(ClinicScheduleDto newScheduleDto)
        {
            var newSchedule = new ClinicSchedule
            {
                StartTime = newScheduleDto.StartTime,
                DayOfWeek = newScheduleDto.DayOfWeek,
                DoctorId = newScheduleDto.DoctorId,
                EndTime = newScheduleDto.EndTime,
                IsAvailable = newScheduleDto.IsAvailable
            };

            await _context.AddAsync(newSchedule);

            return new ClinicScheduleDto
            {
                StartTime = newScheduleDto.StartTime,
                DayOfWeek = newScheduleDto.DayOfWeek,
                DoctorId = newScheduleDto.DoctorId,
                EndTime = newScheduleDto.EndTime,
                IsAvailable = newScheduleDto.IsAvailable
            };
        }

        public async Task<bool> DeleteSchedule(int scheduleId)
        {
            var scheduleToDelete = await _context.ClinicSchedules.FirstOrDefaultAsync(s => s.Id == scheduleId);
            if (scheduleToDelete == null)
                return false;
            _context.Remove(scheduleToDelete);
            return true;
        }

        public async Task<List<ClinicScheduleDto>> GetAllSchedules()
        {
            return await _context.ClinicSchedules.Select(s => new ClinicScheduleDto
            {
                Id = s.Id,
                StartTime = s.StartTime,
                DayOfWeek = s.DayOfWeek,
                DoctorId = s.DoctorId,
                EndTime = s.EndTime,
                IsAvailable = s.IsAvailable
            }).ToListAsync();
        }

        public async Task<ClinicScheduleDto?> GetSchedule(int? scheduleId = null, int? doctorId = null)
        {
            if (scheduleId == null && doctorId == null)
                return null;

            var schedules = await GetAllSchedules();

             if (scheduleId != null && doctorId == null)
                return schedules.Where(s => s.Id == scheduleId).Select(s => new ClinicScheduleDto
                {
                    Id = s.Id,
                    StartTime = s.StartTime,
                    DayOfWeek = s.DayOfWeek,
                    DoctorId = s.DoctorId,
                    EndTime = s.EndTime,
                    IsAvailable = s.IsAvailable
                }).FirstOrDefault();

            else if (doctorId != null && scheduleId == null)
                return schedules.Where(s => s.DoctorId == doctorId).Select(s => new ClinicScheduleDto
                {
                    Id = s.Id,
                    StartTime = s.StartTime,
                    DayOfWeek = s.DayOfWeek,
                    DoctorId = s.DoctorId,
                    EndTime = s.EndTime,
                    IsAvailable = s.IsAvailable
                }).FirstOrDefault();
             
             else
                    return schedules.Where(s => s.Id == scheduleId && s.DoctorId == doctorId).Select(s => new ClinicScheduleDto
                    {
                        Id = s.Id,
                        StartTime = s.StartTime,
                        DayOfWeek = s.DayOfWeek,
                        DoctorId = s.DoctorId,
                        EndTime = s.EndTime,
                        IsAvailable = s.IsAvailable
                    }).FirstOrDefault();
        }

        public async Task<ClinicScheduleDto?> UpdateSchedule(int scheduleId, int doctorId, ClinicScheduleDto dto)
        {
            var existing = await _context.ClinicSchedules.FirstOrDefaultAsync(d => d.Id == scheduleId && d.DoctorId == doctorId);

            if (existing == null)
                return null;

            existing.DayOfWeek = dto.DayOfWeek;
            existing.IsAvailable = dto.IsAvailable;
            existing.StartTime = dto.StartTime;
            existing.EndTime = dto.EndTime;
            existing.DoctorId = existing.DoctorId;

            return new ClinicScheduleDto
            {
                DayOfWeek = dto.DayOfWeek,
                IsAvailable = dto.IsAvailable,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                DoctorId = existing.DoctorId
            };
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
