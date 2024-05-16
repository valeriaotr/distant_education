namespace DistantEducation.Application.Models.StudyMaterial;

public class StudyMaterialModel
{
    private string Id { get; set; }
    private string Name { get; set; }
    private string MaterialType { get; set; }
    private string CourseId { get; set; }

    public StudyMaterialModel(string id, string name, string type, string courseId)
    {
        Id = id;
        Name = name;
        MaterialType = type;
        CourseId = courseId;
    }

    public static StudyMaterialModelBuilder Builder()
    {
        return new StudyMaterialModelBuilder();
    }

    public string GetId()
    {
        return Id;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetMaterialType()
    {
        return MaterialType;
    }

    public string GetCourseId()
    {
        return CourseId;
    }
}