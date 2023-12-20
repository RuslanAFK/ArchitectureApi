namespace ArchitectureApi.Models;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string? PhotoFile { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string Password { get; set; }

    public string Role { get; set; }
    
    // Only for doctor role
    public string? DoctorType { get; set; }
}