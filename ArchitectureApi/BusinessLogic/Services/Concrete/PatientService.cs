using ArchitectureApi.BusinessLogic.Factories;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Dtos;
using ArchitectureApi.Models;
using ArchitectureApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unit;

    public PatientService(IPatientRepository patientRepository, IUnitOfWork unit)
    {
        _patientRepository = patientRepository;
        _unit = unit;
    }

    public User? GetById(int userName)
    {
        return _patientRepository.Get().AsNoTracking().FirstOrDefault(x => x.Id == userName);
    }

    public PatientDto? GetPersonalInfoById(int id)
    {
        return _patientRepository.Get().AsNoTracking()
            .Select(x => new PatientDto()
            {
                Id = x.Id,
                Phone = x.Phone,
                Address = x.Address,
                Avatar = x.PhotoFile,
                Email = x.Email,
                FullName = x.FirstName+" "+x.SecondName+" "+x.LastName
            })
            .FirstOrDefault(x => x.Id == id);
    }

    public void EditPersonalInfoById(int id, EditPatientDto data)
    {
        var patient = new UserBuilder(data.FirstName, data.LastName)
            .WithSecondName(data.SecondName)
            .WithAvatar(data.Avatar)
            .WithAddress(data.Address)
            .WithEmail(data.Email)
            .WithPhone(data.Phone)
            .AsPatient()
            .Build();

        patient.Id = id;
        
        _patientRepository.Update(patient);
        _unit.SaveChanges();
    }

    public void Signup(SignupDto data)
    {
        var patient = new UserBuilder(data.FirstName, data.LastName)
            .WithSecondName(data.SecondName)
            .WithAvatar(data.Avatar)
            .AsPatient()
            .Build();
        
        _patientRepository.Create(patient);
        _unit.SaveChanges();
    }
}