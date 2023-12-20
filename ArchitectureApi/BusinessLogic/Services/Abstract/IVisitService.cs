using ArchitectureApi.BusinessLogic.Dtos;
using ArchitectureApi.Data.Models;
using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.BusinessLogic.Services.Abstract;

public interface IVisitService
{
    Task<List<GetVisitDto>> GetVisits(int userId);
    Task<List<GetTreatmentsDto>> GetTreatments(int patientId);
    Task<Visit> Create(User doctor, User patient, DateTime time, string? notes = null);
    Task<bool> SetFeedback(int doctorId, FeedbackDto dto);
    Task<bool> SetTreatment(int doctorId, TreatmentDto dto);
    Task<bool> DeleteVisit(int patientId, int visitId);
}