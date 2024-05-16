using System.Net;
using DistantEducation.Application.Events.PersonalStatistics.Commands;
using DistantEducation.Application.Events.PersonalStatistics.Queries;
using DistantEducation.Application.Models.Dto.BaseResponse;
using DistantEducation.Application.Models.Dto.PersonalStatistic.GetStatisticsInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace DistantEducation.Presentation.Http.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PersonalStatisticsController : Controller
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IMediator _mediator;

    public PersonalStatisticsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("api/v1/statistics/{statisticId}")]
    public async Task<ResponseBase> GetStatistics([FromRoute]string statisticId)
    {
        try
        {
            var statistics = await _mediator.Send(new GetStatisticsQuery(statisticId));
            double percentageStatistics = await _mediator.Send(new CountPercentageCommand(statisticId));
            var dto = new StatisticsInfoResponseDto(
                statistics.GetId(), 
                statistics.GetCommonAmountOfTasks(), 
                statistics.GetSuccessTasks(), 
                percentageStatistics, 
                HttpStatusCode.OK, 
                "SUCCESS");
            return dto;
        }
        catch(Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("api/v1/statistics/success-tasks/{statisticId}")]
    public async Task<ResponseBase> GetSuccessTasksAmount([FromRoute] string statisticId)
    {
        try
        {
            var successAmount = await _mediator.Send(new GetSuccessTasksAmountQuery(statisticId));
            return new SuccessTasksResponseDto(successAmount, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("api/v1/statistics/common-tasks/{statisticId}")]
    public async Task<ResponseBase> GetCommonTasksAmount([FromRoute] string statisticId)
    {
        try
        {
            var commonTasks = await _mediator.Send(new GetCommonTasksAmountQuery(statisticId));
            return new CommonTasksResponseDto(commonTasks, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpPut("api/v1/statistics/tasks-pass/{statisticId}")]
    public async Task<ResponseBase> PassOneTask([FromRoute] string statisticId)
    {
        try
        {
            await _mediator.Send(new PassOneTaskCommand(statisticId));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }
}