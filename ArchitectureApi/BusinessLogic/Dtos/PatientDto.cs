namespace ArchitectureApi.Dtos;

public class PatientDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Avatar { get; set; }
    public string? Type { get; set; }
}