using ArchitectureApi.Data.Models;
using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Abstract;

public interface IVisitRepository
{
    void Create(Visit item);
    IQueryable<Visit> Get();
    void Update(Visit item);
    void Delete(Visit item);
}