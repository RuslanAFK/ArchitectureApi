using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.Models;

public class HospitalSettings
{
    public string Name { get; set; }
    public string Domain { get; set; }
    public string Email { get; set; }
}