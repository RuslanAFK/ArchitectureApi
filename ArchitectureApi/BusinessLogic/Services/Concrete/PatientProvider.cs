using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Dtos;
using ArchitectureApi.Models;
using ArchitectureApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public class PatientProvider : IPatientProvider
{
    private readonly IPatientRepository _patientRepository;

    public PatientProvider(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public AuthDto? Current
    {
        get
        {
            var user = _patientRepository.Get().AsNoTracking()
                .Select(x => new AuthDto()
                {
                    Id = x.Id, Role = x.Role
                })
                .FirstOrDefault();
            return user;
        }
    }
}