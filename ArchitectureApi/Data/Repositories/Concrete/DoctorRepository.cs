﻿using ArchitectureApi.Enums;
using ArchitectureApi.Models;

namespace ArchitectureApi.Data.Repositories.Concrete;

public class DoctorRepository : BaseRepository<User>, IDoctorRepository
{
    public DoctorRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<User> Get()
    {
        return base.Get().Where(x => x.Role == Roles.Doctor.ToString());
    }
}