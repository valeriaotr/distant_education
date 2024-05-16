namespace DistantEducation.Application.Models.Dto.Registration;

public class UserRegistrationRequestDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Password { get; set; }
    
    public UserRegistrationRequestDto(string firstName, string lastName, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
    }
}