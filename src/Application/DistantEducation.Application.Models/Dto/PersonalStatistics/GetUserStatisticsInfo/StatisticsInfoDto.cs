namespace DistantEducation.Application.Models.Dto.GetUserStatisticsInfo;

public class StatisticsInfoDto
{
    public string? TariffId { get; set; }
    public string StatisticsId { get; set; }
    public int CommonAmountOfTasks { get; set; }
    public int SuccessTasks { get; set; }
}