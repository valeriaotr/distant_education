using System.Net;
using DistantEducation.Application.Events.Course.Commands;
using DistantEducation.Application.Events.Course.Queries;
using DistantEducation.Application.Events.StudyMaterial.Queries;
using DistantEducation.Application.Models.Course;
using DistantEducation.Application.Models.Dto.BaseResponse;
using DistantEducation.Application.Models.Dto.Course.CreateNewCourse;
using DistantEducation.Application.Models.Dto.Course.GetCourseAmountOfTasks;
using DistantEducation.Application.Models.Dto.Course.GetCourseInfo;
using DistantEducation.Application.Models.Dto.Course.GetCourseMaterials;
using DistantEducation.Application.Models.Dto.Course.GetCourseName;
using DistantEducation.Application.Models.Dto.Course.UpdateAmountOfTasks;
using DistantEducation.Application.Models.Dto.Course.UpdateCourseName;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace DistantEducation.Presentation.Http.Controllers;

[ApiController]
[Route("/")]
public class CourseController: Controller
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("api/v1/course/{courseId}/materials")]
    public async Task<ResponseBase> GetCourseMaterials([FromRoute]string courseId)
    {
        try
        {
            var materials = await _mediator.Send(new GetCourseMaterialsIdsQuery(courseId));
            List<MaterialInfoDto> materialInfoDtos = new List<MaterialInfoDto>();
            ListMaterialInfoDto response = new ListMaterialInfoDto(materialInfoDtos, HttpStatusCode.OK, "SUCCESS");
        
            foreach (var material in materials)
            {
                var materialInfoDto = new MaterialInfoDto(courseId,
                    await _mediator.Send(new GetStudyMaterialNameQuery(material.GetId())),
                    await _mediator.Send(new GetStudyMaterialTypeQuery(material.GetId())), 
                    await _mediator.Send(new GetStudyMaterialCourseIdQuery(material.GetId())), 
                    HttpStatusCode.OK, 
                    "SUCCESS");
                response.MaterialInfoDtos.Add(materialInfoDto);
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request {ex.Message}");
        }
        
    }

    [HttpGet("api/v1/course/{courseId}")]
    public async Task<ResponseBase> GetCourse([FromRoute]string courseId)
    {
        try
        {
            CourseModel courseModel = await _mediator.Send(new GetCourseQuery(courseId));
            var course = new CourseInfoResponseDto(
                courseModel.GetId()!,
                courseModel.GetName()!,
                courseModel.GetAmountOfTasks(),
                courseModel.GetTariffId(),
                HttpStatusCode.OK,
                "SUCCESS");

            return course;
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request {ex.Message}");
        }
    }
    
    [HttpGet("api/v1/course-name/{courseId}")]
    public async Task<ResponseBase> GetCourseName([FromRoute]string courseId)
    {
        try
        {
            string name = await _mediator.Send(new GetCourseNameQuery(courseId));
            return new GetCourseNameResponseDto(name, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request {ex.Message}");
        }
    }
    
    [HttpGet("api/v1/course-tasks/{courseId}")]
    public async Task<ResponseBase> GetAmountOfTasks([FromRoute]string courseId)
    {   
        try
        {
            int amount = await _mediator.Send(new GetAmountOfTasksQuery(courseId));
            return new GetAmountOfTasksResponseDto(amount, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request {ex.Message}");
        }
    }

    [HttpPost("api/v1/course-creation")]
    public async Task<ResponseBase> CreateCourse([FromBody] CreateCourseRequestDto createCourseRequestDto)
    {
        try
        {
            var courseModel = CourseModel.Builder()
                .Name(createCourseRequestDto.Name)
                .AmountOfTasks(createCourseRequestDto.TasksAmount)
                .TariffId(createCourseRequestDto.TariffId)
                .Build();
            string courseId = await _mediator.Send(new CreateCourseCommand(courseModel));
            return new CreateCourseResponseDto(courseId, HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request {ex.Message}");
        }
    }

    [HttpPut("api/v1/courses/{courseId}/updateAmountOfTasks")]
    public async Task<ResponseBase> UpdateAmountOfTasks([FromBody]UpdateAmountOfTasksRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateAmountOfTasksCommand(requestDto.CourseId, requestDto.NewTasksAmount));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request {ex.Message}");
        }
    }
    
    [HttpPut("api/v1/courses/{courseId}/updateCourseName")]
    public async Task<ResponseBase> UpdateCourseName([FromBody]UpdateCourseNameRequestDto requestDto)
    {
        try
        {
            await _mediator.Send(new UpdateCourseNameCommand(requestDto.CourseId, requestDto.NewCourseName));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request {ex.Message}");
        }
    }
    
    [HttpDelete("api/v1/course-deletion/{courseId}")]
    public async Task<ResponseBase> DeleteCourse([FromRoute]string courseId)
    {
        try
        {
            await _mediator.Send(new DeleteCourseCommand(courseId));
            return new OkResponseBase(HttpStatusCode.OK, "SUCCESS");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return new ErrorResponseBase(HttpStatusCode.BadRequest, $"Bad request {ex.Message}");
        }
    }
}