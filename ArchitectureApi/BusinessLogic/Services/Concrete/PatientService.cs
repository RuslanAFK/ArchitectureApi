using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Models;

namespace ArchitectureApi.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unit;

    public PatientService(IPatientRepository patientRepository, IUnitOfWork unit)
    {
        _patientRepository = patientRepository;
        _unit = unit;
    }

    public User? GetByUsername(string? userName)
    {
        return _patientRepository.Get().FirstOrDefault(p => p.FirstName + " " + p.LastName == userName);
    }

    public void Signup(User user)
    {
        _patientRepository.Create(user);
        _unit.SaveChanges();
    }
}