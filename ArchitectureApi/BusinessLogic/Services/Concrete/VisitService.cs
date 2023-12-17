using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Dtos;
using ArchitectureApi.Enums;
using ArchitectureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.Services;

public class VisitService : IVisitService
{
    private readonly IVisitRepository _visitRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VisitService(IVisitRepository visitRepository, IUnitOfWork unitOfWork)
    {
        _visitRepository = visitRepository;
        _unitOfWork = unitOfWork;
    }

    public List<GetVisitDto> GetVisits(int patientId)
    {
        if (patientId == default)
            return new List<GetVisitDto>();
        
        var returns = _visitRepository.Get()
            .Where(visit => visit.Participants
                .Any(u => u.Id == patientId && u.Role == Roles.Patient.ToString()))
            .Select(visit => new
            {
                visit.Time,
                Doctor = visit.Participants
                    .Select(x => new
                    {
                        Name = x.SecondName + " " + x.FirstName + " " + x.LastName,
                        x.Role
                    })
                    .FirstOrDefault(x => x.Role == Roles.Doctor.ToString())
            });
        var dto = returns.Select(x => new GetVisitDto()
        {
            Time = x.Time, Doctor = x.Doctor != null ? x.Doctor.Name : string.Empty
        });
        return dto.ToList();
    }
    public List<GetTreatmentsDto> GetTreatments(int patientId)
    {
        if (patientId == default)
            return new List<GetTreatmentsDto>();
        
        var returns = _visitRepository.Get()
            .AsNoTracking()
            .Where(visit => visit.Participants
                                .Any(u => u.Id == patientId &&
                                          u.Role == Roles.Patient.ToString())
                            && visit.Treatment != null)
            .Select(visit => new
            {
                visit.Treatment,
                Doctor = visit.Participants
                    .Select(x => new
                    {
                        Name = x.SecondName + " " + x.FirstName + " " + x.LastName,
                        x.Role
                    })
                    .FirstOrDefault(x => x.Role == Roles.Doctor.ToString())
            });
        var dto = returns.Select(x => new GetTreatmentsDto()
        {
            Treatment = x.Treatment!, Doctor = x.Doctor != null ? x.Doctor.Name : string.Empty
        });
        return dto.ToList();
    }

    public async Task<Visit> Create(User doctor, User patient, DateTime time, string? notes = null)
    {
        if (doctor is null || patient is null)
            throw new ArgumentException("Users cannot be null.");
        if (doctor.Role != Roles.Doctor.ToString() || patient.Role != Roles.Patient.ToString())
            throw new ArgumentException("Users must have correspondent roles.");
        if (time <= DateTime.Now)
            throw new ArgumentException("DateTime cannot be later than now.");
        
        var visit = new Visit()
        {
            Participants =
            {
                doctor, patient
            },
            Time = time,
            Notes = notes
        };
        _visitRepository.Create(visit);
        await _unitOfWork.SaveChanges();
        return visit;
    }
}