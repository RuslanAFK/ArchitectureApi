using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Dtos;
using ArchitectureApi.Models;
using ArchitectureApi.Services;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public abstract class VisitServiceDecorator : IVisitService
{
    private IVisitService Decoratee { get; }

    protected VisitServiceDecorator(IVisitService decoratee)
    {
        Decoratee = decoratee;
    }

    public List<GetVisitDto> GetVisits(int userName)
    {
        return Decoratee.GetVisits(userName);
    }

    public List<GetTreatmentsDto> GetTreatments(int userName)
    {
        return Decoratee.GetTreatments(userName);
    }

    public virtual async Task<Visit> Create(User doctor, User patient, DateTime time, string? notes = null)
    {
       return await Decoratee.Create(doctor, patient, time, notes);
    }
}