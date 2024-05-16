using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Tariff.UpdateTariffInfo;

public class UpdateTariffNameRequestDto:ResponseBase
{
    public string TariffId { get; set; }
    public string NewName { get; set; }

    public UpdateTariffNameRequestDto(string tariffId, string newName, HttpStatusCode statusCode, string message):base(statusCode,message)
    {
        TariffId = tariffId;
        NewName = newName;
    }
}