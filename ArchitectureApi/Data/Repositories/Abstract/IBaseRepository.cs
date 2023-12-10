namespace ArchitectureApi.Data.Repositories.Abstract;

public interface IBaseRepository<T> where T : class
{
    public void Create(T item);
    public IQueryable<T> Get();
    public void Update(T item);
    public void Delete(T item);
}