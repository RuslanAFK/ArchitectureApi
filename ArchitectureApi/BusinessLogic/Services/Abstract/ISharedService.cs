using ArchitectureApi.Dtos;

namespace ArchitectureApi.BusinessLogic.Services.Abstract;

public interface ISharedService
{
    Task<PatientDto?> GetPersonalInfoById(int userName);
}