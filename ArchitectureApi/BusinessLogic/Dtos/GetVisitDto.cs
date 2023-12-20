namespace ArchitectureApi.Dtos;

public class GetVisitDto
{
    public int VisitId { get; set; }
    public DateTime Time { get; set; }
    public string Doctor { get; set; }
    public string Patient { get; set; }
    public bool Declined { get; set; }
    public bool Approved { get; set; }
}