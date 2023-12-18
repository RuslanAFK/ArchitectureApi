using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Abstract;

public interface IVisitUserRepository
{
    IQueryable<UserVisit> Get();
    void Create(UserVisit item);
    void Update(UserVisit item);
    void Delete(UserVisit item);
}