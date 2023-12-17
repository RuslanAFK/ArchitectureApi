using ArchitectureApi.BusinessLogic.Services.Abstract;
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

    public async Task<List<GetVisitDto>> GetVisits(int userName)
    {
        return await Decoratee.GetVisits(userName);
    }

    public async Task<List<GetTreatmentsDto>> GetTreatments(int userName)
    {
        return await Decoratee.GetTreatments(userName);
    }

    public virtual async Task<Visit> Create(User doctor, User patient, DateTime time, string? notes = null)
    {
       return await Decoratee.Create(doctor, patient, time, notes);
    }
}