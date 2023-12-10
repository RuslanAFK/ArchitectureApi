using ArchitectureApi.Models;
using Microsoft.Extensions.Options;

namespace ArchitectureApi.Services.Concrete;

public class HospitalService : IHospitalService
{
    private HospitalSettings _settings;

    public HospitalService(IOptions<HospitalSettings> settings)
    {
        _settings = settings.Value;
    }

    public string GetHospitalName()
    {
        return _settings.Name;
    }
}