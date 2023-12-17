using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.BusinessLogic.Services.Abstract;

public interface IDoctorService
{
    IQueryable<TimeSlot> GetDoctorFreeSlots(int doctorId);
    Task<User?> GetById(int userId);
    Task<DoctorDto?> GetDoctorInfoById(int userId);
    Task<bool> IsDoctorTaken(int doctorId, DateTime time);
    IQueryable<DoctorDto> GetAllDoctorsInfo();
}