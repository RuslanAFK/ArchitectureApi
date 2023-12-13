using ArchitectureApi.Models;
using Microsoft.Extensions.Options;

namespace ArchitectureApi.Services.Concrete;

public class HospitalService : IHospitalService
{
    private HospitalSettings _settings;

    private static HospitalService _self;

    public static HospitalService Self(IServiceProvider serviceProvider)
    {
        if (_self == null)
        {
            var hospitalSettings = serviceProvider.GetService<IOptions<HospitalSettings>>();
            _self = new HospitalService(hospitalSettings);
            return _self;
        }

        return _self;
    }
    
    private HospitalService(IOptions<HospitalSettings> settings)
    {
        _settings = settings.Value;
    }
    

    public string GetHospitalName()
    {
        return _settings.Name;
    }
}