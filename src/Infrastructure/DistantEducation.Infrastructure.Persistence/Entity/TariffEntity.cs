namespace DistantEducation.Infrastructure.Persistence.Entity;

public class TariffEntity
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public int Validity { get; set; }
}