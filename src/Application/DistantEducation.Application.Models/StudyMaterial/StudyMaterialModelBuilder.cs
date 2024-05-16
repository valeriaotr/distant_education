namespace DistantEducation.Application.Models.StudyMaterial;

public class StudyMaterialModelBuilder
{
    private string _id;
    private string _name;
    private string _materialType;
    private string _courseId;

    public StudyMaterialModelBuilder Id(string id)
    {
        _id = id;
        return this;
    }

    public StudyMaterialModelBuilder Name(string name)
    {
        _name = name;
        return this;
    }

    public StudyMaterialModelBuilder MaterialType(string type)
    {
        _materialType = type;
        return this;
    }

    public StudyMaterialModelBuilder CourseId(string courseId)
    {
        _courseId = courseId;
        return this;
    }

    public StudyMaterialModel Build()
    {
        return new StudyMaterialModel(_id, _name, _materialType, _courseId);
    }
}