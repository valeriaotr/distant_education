namespace DistantEducation.Application.Models.TariffUserInfo;

public class TariffUserInfoModelBuilder
{
    private string? _tariffUserInfoId;
    private string _userId;
    private string? _tariffId;
    private string _statisticsId;
    private DateTime _purchaseDate;
    private DateTime _endDate;
    private string _courseId;

    public TariffUserInfoModelBuilder TariffUserInfoId(string? tariffUserInfoId)
    {
        _tariffUserInfoId = tariffUserInfoId;
        return this;
    }

    public TariffUserInfoModelBuilder UserId(string userId)
    {
        _userId = userId;
        return this;
    }

    public TariffUserInfoModelBuilder TariffId(string? tariffId)
    {
        _tariffId = tariffId;
        return this;
    }

    public TariffUserInfoModelBuilder StatisticsId(string statisticsId)
    {
        _statisticsId = statisticsId;
        return this;
    }

    public TariffUserInfoModelBuilder PurchaseDate(DateTime purchaseDate)
    {
        _purchaseDate = purchaseDate;
        return this;
    }

    public TariffUserInfoModelBuilder EndDate(DateTime endDate)
    {
        _endDate = endDate;
        return this;
    }

    public TariffUserInfoModelBuilder CourseId(string courseId)
    {
        _courseId = courseId;
        return this;
    }

    public TariffUserInfoModel? Build()
    {
        return new TariffUserInfoModel(_userId, _tariffUserInfoId, _tariffId, _statisticsId, _purchaseDate, _endDate, _courseId);
    }
}