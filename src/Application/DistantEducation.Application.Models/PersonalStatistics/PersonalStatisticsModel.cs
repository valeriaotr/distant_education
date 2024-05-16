namespace DistantEducation.Application.Models.PersonalStatistics;

public class PersonalStatisticsModel
{
    private string Id { get; set; }
    private int SuccessTasks { get; set; }
    private int CommonAmountOfTasks { get; set; }

    public PersonalStatisticsModel(string id, int successTasks, int commonAmountOfTasks)
    {
        Id = id;
        SuccessTasks = successTasks;
        CommonAmountOfTasks = commonAmountOfTasks;
    }

    public static PersonalStatisticsModelBuilder Builder()
    {
        return new PersonalStatisticsModelBuilder();
    }

    public string GetId()
    {
        return Id;
    }

    public int GetSuccessTasks()
    {
        return SuccessTasks;
    }

    public int GetCommonAmountOfTasks()
    {
        return CommonAmountOfTasks;
    }
}