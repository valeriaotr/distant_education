namespace DistantEducation.Application.Models.User;

public class UserModelBuilder
{
    private string _id;
    private string? _firstName;
    private string? _lastName;
    private string _password;
    private string _tariffId;

    public UserModelBuilder Id(string id)
    {
        _id = id;
        return this;
    }

    public UserModelBuilder FirstName(string? firstName)
    {
        _firstName = firstName;
        return this;
    }

    public UserModelBuilder LastName(string? lastName)
    {
        _lastName = lastName;
        return this;
    }

    public UserModelBuilder Password(string password)
    {
        _password = password;
        return this;
    }

    public UserModelBuilder TariffId(string tariffId)
    {
        _tariffId = tariffId;
        return this;
    }

    public UserModel Build()
    {
        return new UserModel(_id, _firstName, _lastName, _password);
    }
}