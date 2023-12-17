using ArchitectureApi.BusinessLogic.Factories;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Dtos;
using ArchitectureApi.Models;
using ArchitectureApi.Services;
using Microsoft.EntityFrameworkCore;
using Services.Services;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unit;
    
    private readonly ITokenProvider _tokenProvider;


    public PatientService(IPatientRepository patientRepository, IUnitOfWork unit, ITokenProvider tokenProvider)
    {
        _patientRepository = patientRepository;
        _unit = unit;
        _tokenProvider = tokenProvider;
    }

    public User? GetById(int userName)
    {
        return _patientRepository.Get().FirstOrDefault(x => x.Id == userName);
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
        var patient = _patientRepository.Get().First(x => x.Id == id);

        patient.FirstName = data.FirstName ?? patient.FirstName;
        patient.SecondName = data.SecondName ?? patient.SecondName;
        patient.LastName = data.LastName ?? patient.LastName;
        patient.PhotoFile = data.Avatar ?? patient.PhotoFile;
        patient.Email = data.Email ?? patient.Email;
        patient.Address = data.Address ?? patient.Address;
        patient.Phone = data.Phone ?? patient.Phone;
        
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

    public string? Signin(SigninDto user)
    {
        var found = _patientRepository.Get().AsNoTracking()
            .FirstOrDefault(x => user.Email == x.Email && x.Password == user.Password);
        return found is null ? null : _tokenProvider.GenerateToken(found.Id, found.Role);
    }
}