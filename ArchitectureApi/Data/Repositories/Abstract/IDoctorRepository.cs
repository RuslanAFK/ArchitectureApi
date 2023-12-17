using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Abstract;

public interface IDoctorRepository
{
    IQueryable<User> Get();
    void Create(User item);
    void Update(User item);
    void Delete(User item);
}