using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Concrete;

public class VisitUserRepository : BaseRepository<UserVisit>, IVisitUserRepository
{
    public VisitUserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}