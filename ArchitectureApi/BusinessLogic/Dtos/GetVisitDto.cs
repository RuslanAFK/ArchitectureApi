using ArchitectureApi.Models;

namespace ArchitectureApi.Dtos;

public class GetVisitDto
{
    public DateTime Time { get; set; }
    public string Doctor { get; set; }
    public bool Declined { get; set; }
    public bool Approved { get; set; }
}