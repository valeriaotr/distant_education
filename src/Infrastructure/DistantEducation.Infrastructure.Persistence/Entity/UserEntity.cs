namespace DistantEducation.Infrastructure.Persistence.Entity;

public class UserEntity
{
    public string Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Password { get; set; }
}