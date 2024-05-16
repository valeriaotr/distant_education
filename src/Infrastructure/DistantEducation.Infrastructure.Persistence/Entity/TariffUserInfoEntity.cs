namespace DistantEducation.Infrastructure.Persistence.Entity;

public class TariffUserInfoEntity
{
    public string? Id { get; set; }
    public string UserId { get; set; }
    public string? TariffId { get; set; }
    public string StatisticsId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CourseId { get; set; }
}