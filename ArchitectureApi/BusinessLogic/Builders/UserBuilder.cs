using ArchitectureApi.Enums;
using ArchitectureApi.Models;

namespace ArchitectureApi.BusinessLogic.Factories;

public class UserBuilder
{
    private readonly User _user;

    public UserBuilder(string firstName, string lastName)
    {
        _user = new User()
        {
            FirstName = firstName, LastName = lastName
        };
    }

    public UserBuilder WithSecondName(string secondName)
    {
        _user.SecondName = secondName;
        return this;
    }
    
    public UserBuilder WithAvatar(string avatarPath)
    {
        _user.PhotoFile = avatarPath;
        return this;
    }
    
    public UserBuilder WithPhone(string data)
    {
        _user.Phone = data;
        return this;
    }
    
    public UserBuilder WithEmail(string data)
    {
        _user.Email = data;
        return this;
    }
    
    public UserBuilder WithAddress(string avatarPath)
    {
        _user.Address = avatarPath;
        return this;
    }
    
    public UserBuilder AsPatient()
    {
        _user.Role = Roles.Patient.ToString();
        return this;
    }
    
    public UserBuilder AsDoctor()
    {
        _user.Role = Roles.Doctor.ToString();
        return this;
    }
    
    public User Build() => _user;
}