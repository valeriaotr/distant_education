namespace DistantEducation.Infrastructure.Persistence.Entity;

public class CourseEntity
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public int AmountOfTasks { get; set; }
    public string TariffId { get; set; }
}