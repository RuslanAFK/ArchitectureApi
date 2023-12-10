using ArchitectureApi.Models;

namespace ArchitectureApi.Services;

public interface IPatientService
{
    User? GetByUsername(string? userName);
    void Signup(User user);
}