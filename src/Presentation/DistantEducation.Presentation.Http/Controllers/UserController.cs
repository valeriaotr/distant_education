using System.Net;
using DistantEducation.Application.Events.Course.Queries;
using DistantEducation.Application.Events.PersonalStatistics.Commands;
using DistantEducation.Application.Events.PersonalStatistics.Queries;
using DistantEducation.Application.Events.Tariff.Queries;
using DistantEducation.Application.Events.TariffUserInfo.Commands;
using DistantEducation.Application.Events.TariffUserInfo.Queries;
using DistantEducation.Application.Events.User.Commands;
using DistantEducation.Application.Events.User.Queries;
using DistantEducation.Application.Models.Dto.BaseResponse;
using DistantEducation.Application.Models.Dto.GetPurchaseInfo;
using DistantEducation.Application.Models.Dto.GetUserStatisticsInfo;
using DistantEducation.Application.Models.Dto.PersonalStatistics.GetUserStatisticsInfo;
using DistantEducation.Application.Models.Dto.Registration;
using DistantEducation.Application.Models.Dto.Tariff.AddTariff;
using DistantEducation.Application.Models.Dto.Tariff.GetTariffs;
using DistantEducation.Application.Models.Dto.User.GetUserInfo;
using DistantEducation.Application.Models.Dto.User.Regisration;
using DistantEducation.Application.Models.Dto.User.UpdateUserInfo;
using DistantEducation.Application.Models.Tariff;
using DistantEducation.Application.Models.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace DistantEducation.Presentation.Http.Controllers;

[ApiController]
[Route("/")]
public class UserController : Controller
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("api/v1/auth")]
    public async Task<ResponseBase> RegisterUser([FromBody]UserRegistrationRequestDto requestDto)
    {
        try
        {
            var userModel = UserModel.Builder()
                .FirstName(requestDto.FirstName)
                .LastName(requestDto.LastName)
                .Password(requestDto.Password)
                .Build();
            var id = await _mediator.Send(new RegisterNewUserCommand(userModel));
            return new UserRegisterResponseBaseDto(id, HttpStatusCode.OK, "OK");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpPost("api/v1/user-tariffs")]
    public async Task<ResponseBase> AddTariffToUser([FromBody]UserTariffRequestDto requestDto)
    {
        try
        {
            var validity = await _mediator.Send(new GetTariffValidityQuery(requestDto.TariffId));
            var tariffUserInfoModel = await _mediator.Send(new AddTariffToUserCommand(requestDto.UserId, requestDto.TariffId,
                validity, requestDto.CourseId));

            var course = await _mediator.Send(new GetCourseQuery(tariffUserInfoModel.GetCourseId()));
            await _mediator.Send(new AddStatisticsCommand(tariffUserInfoModel.GetStatisticsId(),
                course.GetAmountOfTasks()));
            var response = new UserTariffResponseBaseDto(tariffUserInfoModel.GetTariffUserInfoId(), HttpStatusCode.OK,"SUCCESS");
            
            return response;
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("api/v1/user-tarrifs/{userId}")]
    public async Task<ResponseBase> GetUserTariffs([FromRoute]string userId)
    {
        try
        {
            var tariffsIds = await _mediator.Send(new GetUserTariffsIdsQuery(userId));
            var tariffsModels = new List<TariffModel>();
            
            foreach (var tariffId in tariffsIds)
            {
                var tariffModel = await _mediator.Send(new GetTariffInfoQuery(tariffId));
                tariffsModels.Add(tariffModel!);   
            }
            
            var tariffsDtos = new TariffsResponseBaseDto(HttpStatusCode.OK,"SUCCESS");
            foreach (var model in tariffsModels)
            {
                var newDto = new TariffDto
                {
                    Name = model.GetName(),
                    Price = model.GetPrice(),
                    TariffId = model.GetId(),
                    Validity = model.GetValidity()
                };
                tariffsDtos.Tariffs.Add(newDto);
            }

            return tariffsDtos;
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("api/v1/user-tariffs-info/{userId}")]
    public async Task<ResponseBase> GetFullUserInfo([FromRoute]string userId)
    {
        try
        {
            UserModel userModel = await _mediator.Send(new GetUserQuery(userId));
            var userInfoModel = await _mediator.Send(new GetUserInfoQuery(userId));

            var response = new UserResponseBaseDto(
                userModel.GetId(), 
                userModel.GetFirstName(), 
                userModel.GetLastName(),
                userInfoModel.GetTariffId(), 
                userInfoModel.GetStatisticsId(),
                HttpStatusCode.OK, "SUCCESS");
                
            return response;
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("api/v1/user-purchases/{userId}")]
    public async Task<ResponseBase> GetUserPurchasesInfo([FromRoute]string userId)
    {
        try
        {
            var purchasesInfo = await _mediator.Send(new GetUserPurchasesInfoQuery(userId));
            PurchaseResponseDto responseDto = new PurchaseResponseDto(HttpStatusCode.OK, "SUCCESS");

            foreach (var info in purchasesInfo)
            {
                responseDto.PurchaseInfo.Add(new PurchaseInfoDto
                {
                    TariffId = info!.GetTariffId(),
                    PurchaseDate = info.GetPurchaseDate(),
                    EndDate = info.GetEndDate()
                });
            }

            return responseDto;
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }
    
    [HttpGet("api/v1/user/{userId}/statistics")]
    public async Task<ResponseBase> GetUserStatistics([FromRoute]string userId)
    {
        try
        {
            var statisticsIds = await _mediator.Send(new GetUserStatisticsIdsQuery(userId));
            var statistics = new UserStatisticsResponseDto(HttpStatusCode.OK, "SUCCESS");
            var infoModel = await _mediator.Send(new GetUserInfoQuery(userId));

            foreach (var statisticsId in statisticsIds)
            {
                var statisticsModel = await _mediator.Send(new GetStatisticsQuery(statisticsId));
                statistics.StatisticsInfo.Add(new StatisticsInfoDto
                {
                    StatisticsId = statisticsModel!.GetId(),
                    TariffId = infoModel.GetTariffId(),
                    CommonAmountOfTasks = statisticsModel.GetCommonAmountOfTasks(),
                    SuccessTasks = statisticsModel.GetSuccessTasks()
                });
            }

            return statistics;
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpDelete("api/v1/user/delete/{userId}")]
    public async Task<ResponseBase> DeleteUser([FromRoute]string userId)
    {
        try
        {
            await _mediator.Send(new DeleteUserCommand(userId));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("api/v1/user/{userId}/firstName")]
    public async Task<ResponseBase> GetUserFirstName([FromRoute]string userId)
    {
        try
        {
            var name = await _mediator.Send(new GetUserFirstNameQuery(userId));
            return new UserNameResponseBaseDto(name, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }
    
    [HttpGet("api/v1/user/{userId}/lastName")]
    public async Task<ResponseBase> GetUserLastName([FromRoute]string userId)
    {
        try
        {
            var lastName = await _mediator.Send(new GetUserLastNameQuery(userId));
            return new UserLastNameResponseBaseDto(lastName, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpPut(" api/v1/user/{userId}/updateFirstName")]
    public async Task<ResponseBase> UpdateUserFirstName([FromBody]UpdateUserNameRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateFirstNameCommand(requestDto.UserId, requestDto.NewName));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }
    
    [HttpPut("api/v1/user/{userId}/updateLastName")]
    public async Task<ResponseBase> UpdateUserLastName([FromBody]UpdateUserNameRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateLastNameCommand(requestDto.UserId, requestDto.NewName));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }
    
    [HttpPut("api/v1/user/{userId}/updatePassword")]
    public async Task<ResponseBase> UpdateUserPassword([FromBody]UpdateUserPasswordRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdatePasswordCommand(requestDto.UserId, requestDto.NewPassword));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadGateway, $"Bad request: {e.Message}");
        }
    }

    [HttpDelete("api/v1/user/{userId}/deleteTariff")]
    public async Task<ResponseBase> DeleteParticularTariff(string infoId)
    {
        try
        {
            await _mediator.Send(new DeleteUserInfoCommand(infoId));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("api/v1/user/{userId}/all-user-info")]
    public async Task<ResponseBase> GetAllUserInfo(string userId)
    {
        try
        {
            var info = await _mediator.Send(new GetAllUserInfoQuery(userId));
            var personalInfo = await _mediator.Send(new GetUserQuery(userId));

            var tariffsIds = new List<string?>();
            var statisticsIds = new List<string?>();
            
            foreach (var model in info)
            {
                tariffsIds.Add(model.GetTariffId());
                statisticsIds.Add(model.GetStatisticsId());
            }

            return new AllTariffsUserInfoResponseDto(userId, personalInfo.GetFirstName(),
                personalInfo.GetLastName(), tariffsIds, statisticsIds, HttpStatusCode.OK, "SUCCESS");
            
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }
}