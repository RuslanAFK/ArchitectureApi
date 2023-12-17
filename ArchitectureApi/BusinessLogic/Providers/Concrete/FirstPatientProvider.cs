using ArchitectureApi.BusinessLogic.Providers.Abstract;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Dtos;
using ArchitectureApi.Enums;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.BusinessLogic.Providers.Concrete;

public class FirstPatientProvider : IAuthProvider
{
    private readonly IPatientRepository _patientRepository;

    public FirstPatientProvider(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public AuthDto? GetCurrent(HttpContext httpContext)
    {
        var user = _patientRepository.Get().AsNoTracking()
            .Where(x => x.Role == Roles.Patient.ToString())
            .Select(x => new AuthDto()
            {
                Id = x.Id, Role = x.Role
            })
            .FirstOrDefault();
        return user;
    }
}