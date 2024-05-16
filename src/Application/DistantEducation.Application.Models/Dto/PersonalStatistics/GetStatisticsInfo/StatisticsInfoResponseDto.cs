namespace DistantEducation.Application.Models.Dto.PersonalStatistics.GetStatisticsInfo;

public class StatisticsInfoResponseDto
{
    public string StatisticsId { get; set; }
    public int CommonAmountOfTasks { get; set; }
    public int SuccessTasks { get; set; }
}