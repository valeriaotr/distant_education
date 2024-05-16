using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Tariff.GetTariffInfo;

public class TariffNameResponseBaseDto:ResponseBase
{
    public string Name { get; set; }

    public TariffNameResponseBaseDto(string name, HttpStatusCode statusCode,string message):base(statusCode,message)
    {
        Name = name;
    }
}