using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchitectureApi.Models;

public class Visit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 

    public DateTime Time { get; set; }
    public string? Treatment { get; set; }
    public string? Notes { get; set; }

    public ICollection<User> Participants { get; set; } = new List<User>();
}