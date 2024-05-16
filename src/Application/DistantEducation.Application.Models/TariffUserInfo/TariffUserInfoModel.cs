using System.ComponentModel.DataAnnotations;

namespace DistantEducation.Application.Models.TariffUserInfo;

public class TariffUserInfoModel
{
    private string? _tariffUserInfoId;
    private string _userId;
    private string? _tariffId;
    private string _statisticsId;
    private DateTime _purchaseDate;
    private DateTime _endDate;
    private string _courseId;

    public TariffUserInfoModel(string userId, string? tariffUserInfoId, string? tariffId, string statisticsId,
        DateTime purchaseDate, DateTime endDate, string courseId)
    {
        _tariffUserInfoId = tariffUserInfoId;
        _userId = userId;
        _tariffId = tariffId;
        _statisticsId = statisticsId;
        _purchaseDate = purchaseDate;
        _endDate = endDate;
        _courseId = courseId;
    }

    public static TariffUserInfoModelBuilder Builder()
    {
        return new TariffUserInfoModelBuilder();
    }

    public string? GetTariffUserInfoId()
    {
        return _tariffUserInfoId;
    }

    public string GetUserId()
    {
        return _userId;
    }

    public string? GetTariffId()
    {
        return _tariffId;
    }

    public string GetStatisticsId()
    {
        return _statisticsId;
    }

    public DateTime GetPurchaseDate()
    {
        return _purchaseDate;
    }

    public DateTime GetEndDate()
    {
        return _endDate;
    }

    public string GetCourseId()
    {
        return _courseId;
    }
}