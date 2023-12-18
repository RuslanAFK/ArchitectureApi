using System.Data.Common;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Data.Models;
using ArchitectureApi.Dtos;
using ArchitectureApi.Extensions;
using ArchitectureApi.Models;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public class VisitLogService : VisitServiceDecorator, IVisitService
{
    private ILogger<IVisitService> _logger;
    
    public VisitLogService(IVisitService decoratee, ILogger<IVisitService> logger) : base(decoratee)
    {
        _logger = logger;
    }

    public async Task<List<GetVisitDto>> GetVisits(int userName)
    {
        try
        {
            var visits = await base.GetVisits(userName);
            _logger.LogInformation("Visits fetched: {0}", visits.Count);
            return visits;
        }
        catch (Exception e)
        {
            _logger.LogError("Unhandled exception occurred: {0}", e.Message);
            throw;
        }
    }

    public async Task<List<GetTreatmentsDto>> GetTreatments(int userName)
    {
        try
        {
            var treatments = await base.GetTreatments(userName);
            _logger.LogInformation("Treatments fetched: {0}", treatments.Count);
            return treatments;
        }
        catch (Exception e)
        {
            _logger.LogError("Unhandled exception occurred: {0}", e.Message);
            throw;
        }
    }

    public override async Task<Visit> Create(User doctor, User patient, DateTime time, string? notes = null)
    {
        try
        {
            var visit = await base.Create(doctor, patient, time, notes);
            _logger.LogInformation("Successfully created visit for: {0:f}, doctor: {1}",
                visit.Time,
                doctor.FirstName.Append(doctor.SecondName).Append(doctor.LastName));
            return visit;
        }
        catch (ArgumentException e)
        {
            _logger.LogError("Argument exception occurred: {0}", e.Message);
            throw;
        }
        catch (DbException e)
        {
            _logger.LogError("Database exception occurred: {0}",
                e.InnerException?.Message ?? e.Message);
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError("Unhandled exception occurred: {0}", e.Message);
            throw;
        }
    }
}