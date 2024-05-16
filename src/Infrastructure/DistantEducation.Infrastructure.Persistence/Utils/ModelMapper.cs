using DistantEducation.Application.Models.Course;
using DistantEducation.Application.Models.PersonalStatistics;
using DistantEducation.Application.Models.StudyMaterial;
using DistantEducation.Application.Models.Tariff;
using DistantEducation.Application.Models.TariffUserInfo;
using DistantEducation.Application.Models.User;
using DistantEducation.Infrastructure.Persistence.Entity;

namespace DistantEducation.Infrastructure.Persistence.Utils;

public static class ModelMapper
{
    public static UserEntity MapUserModelToEntity(UserModel userModel)
    {
        return new UserEntity
        {
            FirstName = userModel.GetFirstName(),
            LastName = userModel.GetLastName(),
            Password = userModel.GetPassword(),
            Id = userModel.GetId()
        };
    }
    
    public static StudyMaterialEntity MapStudyMaterialModelToEntity(StudyMaterialModel materialModel)
    {
        return new StudyMaterialEntity
        {
            CourseId = materialModel.GetCourseId(),
            Id = materialModel.GetId(),
            Name = materialModel.GetName(),
            MaterialType = materialModel.GetMaterialType()
        };
    }
    
    public static PersonalStatisticsEntity MapPersonalStatisticsModelToEntity(PersonalStatisticsModel statisticsModel)
    {
        return new PersonalStatisticsEntity
        {
            CommonAmountOfTasks = statisticsModel.GetCommonAmountOfTasks(),
            Id = statisticsModel.GetId(),
            SuccessTasks = statisticsModel.GetSuccessTasks()
        };
    }
    
    public static CourseEntity MapCourseModelToEntity(CourseModel courseModel)
    {
        return new CourseEntity
        {
            Id = courseModel.GetId(),
            Name = courseModel.GetName(),
            AmountOfTasks = courseModel.GetAmountOfTasks(),
            TariffId = courseModel.GetTariffId()
        };
    }
    
    public static TariffEntity MapTariffModelToEntity(TariffModel tariff)
    {
        return new TariffEntity
        {
            Id = tariff.GetId(),
            Name = tariff.GetName(),
            Price = tariff.GetPrice(),
            Validity = tariff.GetValidity()
        };
    }

    public static TariffUserInfoEntity MapTariffUserInfoModelToEntity(TariffUserInfoModel tariffUserInfoModel)
    {
        return new TariffUserInfoEntity
        {
            Id = tariffUserInfoModel.GetTariffUserInfoId(),
            UserId = tariffUserInfoModel.GetUserId(),
            TariffId = tariffUserInfoModel.GetTariffId(),
            StatisticsId = tariffUserInfoModel.GetStatisticsId(),
            PurchaseDate = tariffUserInfoModel.GetPurchaseDate()
        };
    }
    
    public static StudyMaterialEntity MapMaterialModelToEntity(StudyMaterialModel materialModel)
    {
        return new StudyMaterialEntity
        {
            CourseId = materialModel.GetCourseId(),
            Id = materialModel.GetId(),
            Name = materialModel.GetName(),
            MaterialType = materialModel.GetMaterialType()
        };
    }
}