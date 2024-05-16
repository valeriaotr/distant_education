namespace DistantEducation.Application.Models.Dto.Tariff.AddTariff;

public class UserTariffRequestDto
{
    public string UserId { get; set; }
    public string TariffId { get; set; }
    public string CourseId { get; set; }

    public UserTariffRequestDto(string userId, string tariffId, string courseId)
    {
        UserId = userId;
        TariffId = tariffId;
        CourseId = courseId;
    }
}