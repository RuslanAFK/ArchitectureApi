using ArchitectureApi.Models;

namespace ArchitectureApi.Dtos;

public class GetVisitDto
{
    public DateTime Time { get; set; }
    public string Doctor { get; set; }
}