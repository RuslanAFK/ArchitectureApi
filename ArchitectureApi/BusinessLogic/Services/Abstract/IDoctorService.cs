using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.Services;

public interface IDoctorService
{
    IQueryable<TimeSlot> GetDoctorFreeSlots(int doctorId);
    User? GetById(int userId);
    DoctorDto? GetDoctorInfoById(int userId);
    bool IsDoctorTaken(int doctorId, DateTime time);
    IQueryable<DoctorDto> GetAllDoctorsInfo();
}