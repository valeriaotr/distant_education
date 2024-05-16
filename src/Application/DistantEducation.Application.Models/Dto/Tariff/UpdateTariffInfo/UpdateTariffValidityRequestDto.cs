namespace DistantEducation.Application.Models.Dto.Tariff.UpdateTariffInfo;

public class UpdateTariffValidityRequestDto
{
    public string TariffId { get; set; }
    public int NewValidity { get; set; }

    public UpdateTariffValidityRequestDto(string tariffId, int newValidity)
    {
        TariffId = tariffId;
        NewValidity = newValidity;
    }
}