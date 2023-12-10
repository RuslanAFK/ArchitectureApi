using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.Services;

public interface IVisitService
{
    List<GetVisitDto> GetVisits(string userName);
    List<GetTreatmentsDto> GetTreatments(string userName);
    Task<Visit> Create(User doctor, User patient, DateTime time);
}