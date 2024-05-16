namespace DistantEducation.Application.Models.PersonalStatistics;

public class PersonalStatisticsModelBuilder
{
    private string _id;
    private int _successTasks;
    private int _commonAmountOfTasks;

    public PersonalStatisticsModelBuilder Id(string id)
    {
        _id = id;
        return this;
    }

    public PersonalStatisticsModelBuilder SuccessTasks(int successTasks)
    {
        _successTasks = successTasks;
        return this;
    }

    public PersonalStatisticsModelBuilder CommonAmountOfTasks(int commonAmountOfTasks)
    {
        _commonAmountOfTasks = commonAmountOfTasks;
        return this;
    }

    public PersonalStatisticsModel Build()
    {
        return new PersonalStatisticsModel(_id, _successTasks, _commonAmountOfTasks);
    }
}