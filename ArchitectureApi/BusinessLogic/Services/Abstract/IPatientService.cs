using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.Services;

public interface IPatientService
{
    User? GetById(int userName);
    PatientDto? GetPersonalInfoById(int userName);
    void EditPersonalInfoById(int id, EditPatientDto dto);
    void Signup(SignupDto user);
    string? Signin(SigninDto user);
}