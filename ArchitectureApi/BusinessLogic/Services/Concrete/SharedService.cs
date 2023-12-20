using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public class SharedService : ISharedService
{
    private readonly IUsersRepository _usersRepository;

    public SharedService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<PatientDto?> GetPersonalInfoById(int id)
    {
        return await _usersRepository.Get().AsNoTracking()
            .Select(x => new PatientDto()
            {
                Id = x.Id,
                Phone = x.Phone ?? "",
                Address = x.Address ?? "",
                Avatar = x.PhotoFile ?? "",
                Email = x.Email ?? "",
                FullName = x.FullName,
                Type = x.DoctorType
            })
            .FirstOrDefaultAsync(x => x.Id == id);
    }

}