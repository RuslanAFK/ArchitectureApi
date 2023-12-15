namespace ArchitectureApi.Dtos;

public class SignupDto
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string Avatar { get; set; }

    public bool IsAdmin { get; set; }
}