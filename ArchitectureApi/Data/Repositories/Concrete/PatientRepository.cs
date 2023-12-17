using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Enums;
using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Concrete;

public class PatientRepository : BaseRepository<User>, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context)
    {
    }
    public override IQueryable<User> Get()
    {
        return base.Get().Where(x => x.Role == Roles.Patient.ToString());
    }
}