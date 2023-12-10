using System.Data.Common;
using ArchitectureApi.Data.Repositories.Abstract;

namespace ArchitectureApi.Data.Repositories.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChanges()
    { 
        await _dbContext.SaveChangesAsync();
    }
}