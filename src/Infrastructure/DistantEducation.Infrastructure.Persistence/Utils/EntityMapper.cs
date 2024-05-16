using DistantEducation.Application.Models.Course;
using DistantEducation.Application.Models.PersonalStatistics;
using DistantEducation.Application.Models.StudyMaterial;
using DistantEducation.Application.Models.Tariff;
using DistantEducation.Application.Models.TariffUserInfo;
using DistantEducation.Application.Models.User;
using DistantEducation.Infrastructure.Persistence.Entity;

namespace DistantEducation.Infrastructure.Persistence.Utils;

public static class EntityMapper
{
    public static UserModel MapUserEntityToModel(UserEntity user)
    {
        return UserModel.Builder()
            .Id(user.Id)
            .FirstName(user.FirstName)
            .LastName(user.LastName)
            .Build();
    }
    
    public static TariffUserInfoModel? MapTariffUserInfoEntityToModel(TariffUserInfoEntity entity)
    {
        return TariffUserInfoModel
            .Builder()
            .TariffUserInfoId(entity.Id)
            .TariffId(entity.TariffId)
            .PurchaseDate(entity.PurchaseDate)
            .UserId(entity.UserId)
            .StatisticsId(entity.StatisticsId)
            .Build();
    }
    
    public static TariffModel MapTariffEntityToModel(TariffEntity tariff)
    {
        return TariffModel.Builder()
            .Id(tariff.Id)
            .Name(tariff.Name)
            .Price(tariff.Price)
            .Validity(tariff.Validity)
            .Build();
    }
    
    public static StudyMaterialModel MapStudyMaterialEntityToModel(StudyMaterialEntity materialEntity)
    {
        return StudyMaterialModel.Builder()
            .Id(materialEntity.Id)
            .Name(materialEntity.Name)
            .MaterialType(materialEntity.MaterialType)
            .CourseId(materialEntity.CourseId)
            .Build();
    }
    
    public static PersonalStatisticsModel MapPersonalStatisticsEntityToModel(PersonalStatisticsEntity statistic)
    {
        return PersonalStatisticsModel.Builder()
            .Id(statistic.Id)
            .SuccessTasks(statistic.SuccessTasks)
            .CommonAmountOfTasks(statistic.CommonAmountOfTasks).Build();
    }
    
    public static CourseModel MapCourseEntityToModel(CourseEntity courseEntity)
    {
        return CourseModel.Builder()
            .Id(courseEntity.Id)
            .Name(courseEntity.Name)
            .AmountOfTasks(courseEntity.AmountOfTasks)
            .TariffId(courseEntity.TariffId)
            .Build();
    }
}