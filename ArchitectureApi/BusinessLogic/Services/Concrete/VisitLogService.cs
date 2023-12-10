using System.Data.Common;
using ArchitectureApi.Dtos;
using ArchitectureApi.Extensions;
using ArchitectureApi.Models;

namespace ArchitectureApi.Services.Concrete;

public class VisitLogService : IVisitService
{
    private IVisitService Decoratee { get; }
    private ILogger<IVisitService> _logger;
    
    public VisitLogService(IVisitService decoratee, ILogger<IVisitService> logger)
    {
        Decoratee = decoratee;
        _logger = logger;
    }

    public List<GetVisitDto> GetVisits(string userName)
    {
        try
        {
            var visits = Decoratee.GetVisits(userName);
            _logger.LogInformation("Visits fetched: {0}", visits.Count);
            return visits;
        }
        catch (Exception e)
        {
            _logger.LogError("Unhandled exception occurred: {0}", e.Message);
            throw;
        }
    }

    public List<GetTreatmentsDto> GetTreatments(string userName)
    {
        try
        {
            var treatments = Decoratee.GetTreatments(userName);
            _logger.LogInformation("Treatments fetched: {0}", treatments.Count);
            return treatments;
        }
        catch (Exception e)
        {
            _logger.LogError("Unhandled exception occurred: {0}", e.Message);
            throw;
        }
    }

    public async Task<Visit> Create(User doctor, User patient, DateTime time)
    {
        try
        {
            var visit = await Decoratee.Create(doctor, patient, time);
            _logger.LogInformation("Successfully created visit for: {0:f}, doctor: {1}",
                visit.Time,
                doctor.FirstName.AppendLastName(doctor.LastName));
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