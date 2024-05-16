using System.Net;
using DistantEducation.Application.Contracts.ServicesInterfaces;
using DistantEducation.Application.Events.Tariff.Commands;
using DistantEducation.Application.Events.Tariff.Queries;
using DistantEducation.Application.Exceptions.Tariff;
using DistantEducation.Application.Models.Dto.BaseResponse;
using DistantEducation.Application.Models.Dto.Tariff.CreateNewTariff;
using DistantEducation.Application.Models.Dto.Tariff.GetTariffInfo;
using DistantEducation.Application.Models.Dto.Tariff.GetTariffs;
using DistantEducation.Application.Models.Dto.Tariff.UpdateTariffInfo;
using DistantEducation.Application.Models.Tariff;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace DistantEducation.Presentation.Http.Controllers;

[ApiController]
[Route("/")]
public class TariffController : Controller
{
    private readonly IMediator _mediator;
    private static Logger _logger = LogManager.GetCurrentClassLogger();

    public TariffController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("api/v1/tariffs/{tariffId}")]
    public async Task<ResponseBase> GetTariffInfo([FromRoute]string tariffId)
    {
        try
        {
            var tariffModel = await _mediator.Send(new GetTariffInfoQuery(tariffId));
            var response = new TariffResponseBaseDto(HttpStatusCode.OK,"SUCCESS")
            {
                Id = tariffId,
                Name = tariffModel.GetName(),
                Price = tariffModel.GetPrice(),
                Validity = tariffModel.GetValidity()
            };
            return response;
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }

    [HttpGet("api/v1/tariffs")]
    public async Task<ResponseBase> GetAllTariffs()
    {
        try
        {
            var tariffs = await _mediator.Send(new GetAllTariffsQuery());
            var response = new TariffsResponseBaseDto(HttpStatusCode.OK,"SUCCESS");
            
            foreach (var tariff in tariffs)
            {
                var responseDto = new TariffDto
                {
                    TariffId = tariff.GetId(),
                    Name = tariff.GetName(),
                    Price = tariff.GetPrice(),
                    Validity = tariff.GetValidity()
                };
                response.Tariffs.Add(responseDto);
            }

            return response;
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }

    [HttpPost("api/v1/tariffs/addNewTariff")]
    public async Task<ResponseBase> AddNewTariff([FromBody]CreateTariffRequestDto requestDto)
    {
        try
        {
            var model = TariffModel.Builder()
                .Name(requestDto.Name)
                .Price(requestDto.Price)
                .Validity(requestDto.Validity)
                .Build();
            return  new CreateTariffResponseBaseDto(await _mediator.Send(new AddNewTariffCommand(model)),HttpStatusCode.OK,"SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }

    [HttpDelete("api/v1/tariffs/delete/{tariffId}")]
    public async Task<ResponseBase> DeleteTariff([FromRoute]string tariffId)
    {
        try
        {
            await _mediator.Send(new DeleteTariffCommand(tariffId));
            return new OkResponseBase(HttpStatusCode.OK,"SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }
    
    [HttpGet("api/v1/tariffs/{tariffId}/name")]
    public async Task<ResponseBase> GetTariffName([FromRoute]string tariffId)
    {
        try
        {
            var name = await _mediator.Send(new GetTariffNameQuery(tariffId));
            if (name == null)
            {
                throw new NullTariffException($"No tariff with ID {tariffId}");
            }
            return new TariffNameResponseBaseDto(name,HttpStatusCode.OK,"SUCCESS");
            
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }

    [HttpGet("api/v1/tariffs/{tariffId}/price")]
    public async Task<ResponseBase> GetTariffPrice([FromRoute]string tariffId)
    {
        try
        {
            var price = await _mediator.Send(new GetTariffPriceQuery(tariffId));
            

            return new TariffPriceResponseBaseDto(price,HttpStatusCode.OK,"SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }

    [HttpGet("api/v1/tariffs/{tariffId}/validity")]
    public async Task<ResponseBase> GetTariffValidity([FromRoute]string tariffId)
    {
        try
        {
            var validity = await _mediator.Send(new GetTariffValidityQuery(tariffId));
            
            return new TariffValidityResponseBaseDto(validity,HttpStatusCode.OK,"SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }

    [HttpPut("api/v1/tariffs/{tariffId}/updateName")]
    public async Task<ResponseBase> UpdateTariffName([FromBody]UpdateTariffNameRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateTariffNameCommand(requestDto.TariffId, requestDto.NewName));
            return new OkResponseBase(HttpStatusCode.OK,"SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }

    [HttpPut("api/v1/tariffs/{tariffId}/updatePrice")]
    public async Task<ResponseBase> UpdateTariffPrice([FromBody]UpdateTariffPriceRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateTariffPriceCommand(requestDto.TariffId, requestDto.NewPrice));
            return new OkResponseBase(HttpStatusCode.OK,"SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }

    [HttpPut("api/v1/tariffs/{tariffId}/updateValidity")]
    public async Task<ResponseBase> UpdateTariffValidity([FromBody]UpdateTariffValidityRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateTariffValidityCommand(requestDto.TariffId, requestDto.NewValidity));
            return new OkResponseBase(HttpStatusCode.OK,"SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, e.Message);
        }
    }
}