namespace DistantEducation.Application.Models.Course;

public class CourseModelBuilder
{
    private string? _id;
    private string? _name;
    private int _amountOfTasks;
    private string _tariffId;

    public CourseModelBuilder Id(string? id)
    {
        _id = id;
        return this;
    }

    public CourseModelBuilder Name(string? name)
    {
        _name = name;
        return this;
    }

    public CourseModelBuilder AmountOfTasks(int amountOfTasks)
    {
        _amountOfTasks = amountOfTasks;
        return this;
    }

    public CourseModelBuilder TariffId(string tariffId)
    {
        _tariffId = tariffId;
        return this;
    }

    public CourseModel Build()
    {
        return new CourseModel(_id, _name, _amountOfTasks, _tariffId);
    }
}