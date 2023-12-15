using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.Services;

public interface IPatientProvider
{
    AuthDto? Current { get; }
}