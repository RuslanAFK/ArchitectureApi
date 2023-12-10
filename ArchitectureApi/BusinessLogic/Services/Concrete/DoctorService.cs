using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Enums;
using ArchitectureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IVisitRepository _visitRepository;

    public DoctorService(IVisitRepository visitRepository, IDoctorRepository doctorRepository)
    {
        _visitRepository = visitRepository;
        _doctorRepository = doctorRepository;
    }

    public IQueryable<TimeSlot> GetDoctorFreeSlots(int doctorId)
    {
        return _doctorRepository.Get()
            .AsNoTracking()
            .Where(x => x.Id == doctorId)
            .SelectMany(x => x.FreeTimeSlots);
    }

    public User? GetById(int userId)
    {
        return _doctorRepository.Get().FirstOrDefault(d => d.Id == userId);
    }

    public bool IsDoctorTaken(int doctorId, DateTime time)
    {
        return _visitRepository.Get()
            .AsNoTracking()
            .Any(visit => visit.Participants.Any(u => u.Id == doctorId && u.Role == Roles.Patient.ToString()) &&
                          visit.Time == time);
    }
}