namespace ArchitectureApi.Models;

public class TimeSlot
{
    public int Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public int DoctorId { get; set; }
    public User Doctor { get; set; }
}