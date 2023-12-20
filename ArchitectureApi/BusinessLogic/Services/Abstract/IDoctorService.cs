using ArchitectureApi.Dtos;
using ArchitectureApi.Models;

namespace ArchitectureApi.BusinessLogic.Services.Abstract;

public interface IDoctorService
{
    Task<User?> GetById(int userId);
    Task<DoctorDto?> GetDoctorInfoById(int userId);
    Task<bool> IsDoctorTaken(int doctorId, DateTime time);
    IQueryable<DoctorDto> GetAllDoctorsInfo();
}