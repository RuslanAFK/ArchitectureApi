using ArchitectureApi.Models;

namespace ArchitectureApi.Services;

public interface IDoctorService
{
    IQueryable<TimeSlot> GetDoctorFreeSlots(int doctorId);
    User? GetById(int userId);
    bool IsDoctorTaken(int doctorId, DateTime time);
}