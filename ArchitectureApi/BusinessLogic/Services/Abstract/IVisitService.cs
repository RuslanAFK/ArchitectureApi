using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.BusinessLogic.Services.Abstract;

public interface IVisitService
{
    List<GetVisitDto> GetVisits(int patientId);
    List<GetTreatmentsDto> GetTreatments(int patientId);
    Task<Visit> Create(User doctor, User patient, DateTime time, string? notes = null);
}