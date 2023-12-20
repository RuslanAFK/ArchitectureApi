using ArchitectureApi.BusinessLogic.Dtos;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Data.Models;
using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public abstract class VisitServiceDecorator : IVisitService
{
    private IVisitService Decoratee { get; }

    protected VisitServiceDecorator(IVisitService decoratee)
    {
        Decoratee = decoratee;
    }

    public async Task<List<GetVisitDto>> GetVisits(int userId)
    {
        return await Decoratee.GetVisits(userId);
    }

    public Task<TimerDto> GetTimer(int userId, int visitId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetTreatmentsDto>> GetTreatments(int userName)
    {
        return await Decoratee.GetTreatments(userName);
    }

    public virtual async Task<Visit> Create(User doctor, User patient, DateTime time, string? notes = null)
    {
       return await Decoratee.Create(doctor, patient, time, notes);
    }

    public Task<bool> SetFeedback(int doctorId, FeedbackDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SetTreatment(int doctorId, TreatmentDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteVisit(int patientId, int visitId)
    {
        throw new NotImplementedException();
    }
}