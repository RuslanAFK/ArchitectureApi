using ArchitectureApi.Data.Repositories.Abstract;

namespace ArchitectureApi.Data.Repositories.Concrete;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected BaseRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }
    private AppDbContext DbContext { get; }
    public virtual void Create(T item)
    {
        DbContext.Add(item);
    }
    public virtual IQueryable<T> Get()
    {
        return DbContext.Set<T>();
    }
    public virtual void Update(T item)
    {
        DbContext.Update(item);
    }
    public virtual void Delete(T item)
    {
        DbContext.Remove(item);
    }
}