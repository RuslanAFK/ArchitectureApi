using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Concrete;

public class UserRepository : BaseRepository<User>, IUsersRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}