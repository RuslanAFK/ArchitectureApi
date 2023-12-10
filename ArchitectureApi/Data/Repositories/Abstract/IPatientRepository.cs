using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Concrete;

public interface IPatientRepository
{
    IQueryable<User> Get();
    void Create(User item);
    void Update(User item);
    void Delete(User item);
}