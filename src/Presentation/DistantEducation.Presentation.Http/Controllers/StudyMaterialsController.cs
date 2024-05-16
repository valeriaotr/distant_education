using System.Net;
using DistantEducation.Application.Contracts.ServicesInterfaces;
using DistantEducation.Application.Events.StudyMaterial.Commands;
using DistantEducation.Application.Events.StudyMaterial.Queries;
using DistantEducation.Application.Exceptions.StudyMaterial;
using DistantEducation.Application.Models.Dto.BaseResponse;
using DistantEducation.Application.Models.Dto.StudyMaterial.AddNewMaterial;
using DistantEducation.Application.Models.Dto.StudyMaterial.GetMaterialInfo;
using DistantEducation.Application.Models.Dto.StudyMaterial.UpdateMaterialInfo;
using DistantEducation.Application.Models.StudyMaterial;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace DistantEducation.Presentation.Http.Controllers;

[ApiController]
[Route("/")]
public class StudyMaterialController : Controller
{
    private readonly IMediator _mediator;
    private static Logger _logger = LogManager.GetCurrentClassLogger();

    public StudyMaterialController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("api/v1/materials/addNewMaterial")]
    public async Task<ResponseBase> CreateMaterial([FromBody] MaterialRequestDto requestDto)
    {
        try
        {
            var model = StudyMaterialModel.Builder()
                .Name(requestDto.Name)
                .MaterialType(requestDto.MaterialType)
                .CourseId(requestDto.CourseId)
                .Build();
            var id = await _mediator.Send(new CreateMaterialCommand(model));
            return new MaterialResponseDto(id, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("materials/{materialId}")]
    public async Task<ResponseBase> GetStudyMaterialsInfo([FromRoute] string materialId)
    {
        try
        {
            var studyMaterialModel = await _mediator.Send(new GetStudyMaterialsInfoQuery(materialId));
            return new StudyMaterialResponseDto(studyMaterialModel.GetId(), studyMaterialModel.GetName(),
                studyMaterialModel?.GetMaterialType(), studyMaterialModel?.GetCourseId(), HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("materials/{materialId}/name")]
    public async Task<ResponseBase> GetStudyMaterialName([FromRoute] string materialId)
    {
        try
        {
            var name = await _mediator.Send(new GetStudyMaterialNameQuery(materialId));
            if (name == null)
            {
                throw new NullStudyMaterialException($"No material with ID {materialId}");
            }

            return new MaterialNameResponseDto(name, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpGet("materials/{materialId}/type")]
    public async Task<ResponseBase> GetStudyMaterialType([FromRoute] string materialId)
    {
        try
        {
            var type = await _mediator.Send(new GetStudyMaterialTypeQuery(materialId));
            if (type == null)
            {
                throw new NullStudyMaterialException($"No material with ID {materialId}");
            }

            return new MaterialTypeResponseDto(type, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpPut("materials/{materialId}/updateName")]
    public async Task<ResponseBase> UpdateStudyMaterialName([FromBody] UpdateStudyMaterialNameRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateStudyMaterialNameCommand(requestDto.MaterialId, requestDto.NewName));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpPut("materials/{materialId}/updateType")]
    public async Task<ResponseBase> UpdateStudyMaterialType([FromBody] UpdateStudyMaterialTypeRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateStudyMaterialTypeCommand(requestDto.MaterialId, requestDto.MaterialType));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {e.Message}");
        }
    }

    [HttpDelete("materials/{materialId}/deleteMaterial")]
    public async Task<ResponseBase> DeleteStudyMaterial([FromRoute] string materialId)
    {
        try
        {
            await _mediator.Send(new DeleteStudyMaterialCommand(materialId));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request: {ex.Message}");
        }
    }
}