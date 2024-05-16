using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Tariff.GetTariffInfo;

public class TariffResponseBaseDto:ResponseBase
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Validity { get; set; }

    public TariffResponseBaseDto(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
    }
}