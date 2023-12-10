using ArchitectureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}