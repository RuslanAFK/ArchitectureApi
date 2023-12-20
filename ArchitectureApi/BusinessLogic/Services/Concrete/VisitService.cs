using ArchitectureApi.BusinessLogic.Dtos;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Data.Models;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Dtos;
using ArchitectureApi.Enums;
using ArchitectureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public class VisitService : IVisitService
{
    private readonly IVisitRepository _visitRepository;
    private readonly IVisitUserRepository _visitUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VisitService(IVisitRepository visitRepository, IUnitOfWork unitOfWork, IVisitUserRepository visitUserRepository)
    {
        _visitRepository = visitRepository;
        _unitOfWork = unitOfWork;
        _visitUserRepository = visitUserRepository;
    }

    public async Task<List<GetVisitDto>> GetVisits(int patientId)
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
                    .FirstOrDefault(x => x.Role == Roles.Doctor.ToString()),
                visit.Approved, visit.Declined
            });
        var dto = returns.Select(x => new GetVisitDto()
        {
            Time = x.Time, Doctor = x.Doctor != null ? x.Doctor.Name : string.Empty,
            Approved = x.Approved, Declined = x.Declined
        });
        return await dto.ToListAsync();
    }
    public async Task<List<GetTreatmentsDto>> GetTreatments(int patientId)
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
            })
            .Where(x => x.Doctor != null);
        var dto = returns.Select(x => new GetTreatmentsDto()
        {
            Treatment = x.Treatment!, Doctor = x.Doctor!.Name
        });
        return await dto.ToListAsync();
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
    
    public async Task<bool> SetFeedback(int doctorId, FeedbackDto dto)
    {
        var visit = await GetVisitByRole(dto.VisitId, doctorId, Roles.Doctor);
        if (visit == null)
            return false;

        if (dto.Approve)
        {
            visit.Approved = true;
            visit.Declined = false;
        }
        else
        {
            visit.Approved = false;
            visit.Declined = true;
        }

        await _unitOfWork.SaveChanges();
        return true;
    }
    
    public async Task<bool> SetTreatment(int doctorId, TreatmentDto dto)
    {
        var visit = await GetVisitByRole(dto.VisitId, doctorId, Roles.Doctor);
        if (visit == null)
            return false;

        visit.Treatment = dto.Treatment;
        await _unitOfWork.SaveChanges();
        return true;
    }
    
    public async Task<bool> DeleteVisit(int patientId, int visitId)
    {
        var visit = await GetVisitByRole(patientId, visitId, Roles.Patient);
        if (visit == null)
            return false;

        _visitRepository.Delete(visit);
        await _unitOfWork.SaveChanges();
        return true;
    }
    
    private async Task<Visit?> GetVisitByRole(int visitId, int patientId, Roles role)
    {
        return await _visitRepository.Get()
            .Where(x => x.Participants.Any(p => p.Role == role.ToString() && p.Id == patientId))
            .FirstOrDefaultAsync(x => x.Id == visitId);
    }
}