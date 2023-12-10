namespace ArchitectureApi.Data.Repositories.Abstract;

public interface IUnitOfWork
{
    Task SaveChanges();
}