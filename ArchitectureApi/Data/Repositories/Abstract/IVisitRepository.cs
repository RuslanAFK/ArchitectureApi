using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Concrete;

public interface IVisitRepository
{
    void Create(Visit item);
    IQueryable<Visit> Get();
    void Update(Visit item);
    void Delete(Visit item);
}