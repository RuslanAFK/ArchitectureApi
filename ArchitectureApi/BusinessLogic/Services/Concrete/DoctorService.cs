using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Dtos;
using ArchitectureApi.Enums;
using ArchitectureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

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

    public Task<User?> GetById(int userId)
    {
        return _doctorRepository.Get().FirstOrDefaultAsync(d => d.Id == userId);
    }

    public async Task<DoctorDto?> GetDoctorInfoById(int userId)
    {
        return await GetAllDoctorsInfo()
            .FirstOrDefaultAsync(d => d.Id == userId);
    }

    public async Task<bool> IsDoctorTaken(int doctorId, DateTime time)
    {
        return await _visitRepository.Get()
            .AsNoTracking()
            .AnyAsync(visit => visit.Participants.Any(u => u.Id == doctorId && u.Role == Roles.Doctor.ToString()) &&
                               visit.Time == time && visit.Approved);
    }

    public IQueryable<DoctorDto> GetAllDoctorsInfo()
    {
        return _doctorRepository.Get().AsNoTracking()
            .Select(x => new DoctorDto()
            {
                Id = x.Id,
                FullName = x.FullName,
                DoctorType = x.DoctorType,
                Avatar = x.PhotoFile
            });
    }
}