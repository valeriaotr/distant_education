namespace DistantEducation.Application.Models.Course;

public class CourseModel
{
    private string? Id { get; set; }
    private string? Name { get; set; }
    private int AmountOfTasks { get; set; }
    private string TariffId { get; set; }

    public CourseModel(string? id, string? name, int amountOfTasks, string tariffId)
    {
        Id = id;
        Name = name;
        AmountOfTasks = amountOfTasks;
        TariffId = tariffId;
    }

    public static CourseModelBuilder Builder()
    {
        return new CourseModelBuilder();
    }

    public string? GetId()
    {
        return Id;
    }

    public string? GetName()
    {
        return Name;
    }

    public int GetAmountOfTasks()
    {
        return AmountOfTasks;
    }

    public string GetTariffId()
    {
        return TariffId;
    }
}