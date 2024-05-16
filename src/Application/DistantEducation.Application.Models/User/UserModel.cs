namespace DistantEducation.Application.Models.User;

public class UserModel
{
    private string Id { get; set; }
    private string? FirstName { get; set; }
    private string? LastName { get; set; }
    private string Password { get; set; }

    public UserModel(string id, string? firstName, string? lastName, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
    }

    public static UserModelBuilder Builder()
    {
        return new UserModelBuilder();
    }

    public string GetId()
    {
        return Id;
    }

    public string? GetFirstName()
    {
        return FirstName;
    }

    public string? GetLastName()
    {
        return LastName;
    }

    public string GetPassword()
    {
        return Password;
    }
}