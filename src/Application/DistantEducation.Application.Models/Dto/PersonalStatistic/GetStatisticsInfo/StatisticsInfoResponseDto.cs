using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.PersonalStatistic.GetStatisticsInfo;

public class StatisticsInfoResponseDto : ResponseBase
{
    public string StatisticsId { get; set; }
    public int CommonAmountOfTasks { get; set; }
    public int SuccessTasks { get; set; }
    public double PercentSuccessTasks { get; set; }

    public StatisticsInfoResponseDto(string statisticsId, int commonAmountOfTasks, int successTasks,
        double percentSuccessTasks, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        StatisticsId = statisticsId;
        CommonAmountOfTasks = commonAmountOfTasks;
        SuccessTasks = successTasks;
        PercentSuccessTasks = percentSuccessTasks;
    }
}