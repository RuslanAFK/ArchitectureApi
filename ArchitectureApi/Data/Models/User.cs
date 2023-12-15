namespace ArchitectureApi.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? SecondName { get; set; }
    public string LastName { get; set; }
    public string? PhotoFile { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }

    public string Role { get; set; }
    
    public ICollection<Visit> Visits { get; set; }
    
    // Only for doctor role
    public string? DoctorType { get; set; }
    public ICollection<TimeSlot> FreeTimeSlots { get; set; }
}