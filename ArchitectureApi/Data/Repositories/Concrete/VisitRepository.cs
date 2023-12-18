using ArchitectureApi.Data.Models;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Concrete;

public class VisitRepository : BaseRepository<Visit>, IVisitRepository
{
    public VisitRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}