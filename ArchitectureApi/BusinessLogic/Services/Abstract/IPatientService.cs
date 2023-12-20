using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.BusinessLogic.Services.Abstract;

public interface IPatientService
{
    Task<User?> GetById(int userName);
    Task EditPersonalInfoById(int id, EditPatientDto dto);
    Task Signup(SignupDto user);
    Task<string?> Signin(SigninDto user);
}