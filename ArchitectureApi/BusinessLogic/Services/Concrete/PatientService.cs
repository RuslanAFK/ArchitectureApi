using ArchitectureApi.BusinessLogic.Factories;
using ArchitectureApi.BusinessLogic.Services.Abstract;
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

    public Task<User?> GetById(int userName)
    {
        return _patientRepository.Get().FirstOrDefaultAsync(x => x.Id == userName);
    }

    public async Task<PatientDto?> GetPersonalInfoById(int id)
    {
        return await _patientRepository.Get().AsNoTracking()
            .Select(x => new PatientDto()
            {
                Id = x.Id,
                Phone = x.Phone ?? "",
                Address = x.Address ?? "",
                Avatar = x.PhotoFile ?? "",
                Email = x.Email ?? "",
                FullName = x.FirstName+" "+x.SecondName+" "+x.LastName
            })
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task EditPersonalInfoById(int id, EditPatientDto data)
    {
        var patient = await _patientRepository.Get().FirstAsync(x => x.Id == id);

        patient.FirstName = data.FirstName ?? patient.FirstName;
        patient.SecondName = data.SecondName ?? patient.SecondName;
        patient.LastName = data.LastName ?? patient.LastName;
        patient.PhotoFile = data.Avatar ?? patient.PhotoFile;
        patient.Email = data.Email ?? patient.Email;
        patient.Address = data.Address ?? patient.Address;
        patient.Phone = data.Phone ?? patient.Phone;
        
        await _unit.SaveChanges();
    }

    public async Task Signup(SignupDto data)
    {
        var patient = new UserBuilder(data.FirstName, data.LastName)
            .WithSecondName(data.SecondName)
            .WithAvatar(data.Avatar)
            .AsPatient()
            .Build();
        
        _patientRepository.Create(patient);
        await _unit.SaveChanges();
    }

    public async Task<string?> Signin(SigninDto user)
    {
        var found = await _patientRepository.Get().AsNoTracking()
            .FirstOrDefaultAsync(x => user.Email == x.Email && x.Password == user.Password);
        return found is null ? null : _tokenProvider.GenerateToken(found.Id, found.Role);
    }
}