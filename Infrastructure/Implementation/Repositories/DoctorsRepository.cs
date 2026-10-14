using Application.DTOs.Doctors;
using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Implementation.Repositories
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DoctorDto> AddNewDoctor(DoctorDto dto)
        {
            var newDoctor = new Doctor
            {
                Id = dto.Id,
                UserId = dto.UserId,
                ConsultationFee = dto.ConsultationFee,
                FullName = dto.FullName,
                IsActive = dto.IsActive,
                PhoneNumber = dto.PhoneNumber,
                Specialty = dto.Specialty
            };

            await _context.AddAsync(newDoctor);

            return new DoctorDto
            {
                Id = dto.Id,
                UserId = dto.UserId,
                ConsultationFee = dto.ConsultationFee,
                FullName = dto.FullName,
                IsActive = dto.IsActive,
                PhoneNumber = dto.PhoneNumber,
                Specialty = dto.Specialty
            };
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            var doctorToDelete = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctorToDelete == null)
                return false;
            _context.Remove(doctorToDelete);
            return true;
        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            return await _context.Doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId,
                ConsultationFee = d.ConsultationFee,
                FullName = d.FullName,
                IsActive = d.IsActive,
                PhoneNumber = d.PhoneNumber,
                Specialty = d.Specialty

            }).ToListAsync();
        }

        public async Task<List<DoctorDto>> GetAllDoctorsBySpeciality(string speciality)
        {
            return await _context.Doctors.Where(d => d.Specialty.ToLower() == speciality.ToLower())
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    UserId = d.UserId,
                    ConsultationFee = d.ConsultationFee,
                    FullName = d.FullName,
                    IsActive = d.IsActive,
                    PhoneNumber = d.PhoneNumber,
                    Specialty = d.Specialty

                }).ToListAsync();
        }

        public  async Task<DoctorDto?> GetDoctorById(int id)
        {
            return await _context.Doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId,
                ConsultationFee = d.ConsultationFee,
                FullName = d.FullName,
                IsActive = d.IsActive,
                PhoneNumber = d.PhoneNumber,
                Specialty = d.Specialty

            }).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DoctorDto?> UpdateDoctor(int id, DoctorDto dto)
        {
            var existingDoctor = await _context.Doctors
        .FirstOrDefaultAsync(d => d.Id == id);

            if (existingDoctor == null)
                return null;

            existingDoctor.FullName = dto.FullName;
            existingDoctor.Specialty = dto.Specialty;
            existingDoctor.PhoneNumber = dto.PhoneNumber;
            existingDoctor.ConsultationFee = dto.ConsultationFee;

            return new DoctorDto
            {
                FullName = existingDoctor.FullName,
                Specialty = existingDoctor.Specialty,
                PhoneNumber = existingDoctor.PhoneNumber,
                ConsultationFee = existingDoctor.ConsultationFee
            };
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
