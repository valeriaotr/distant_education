namespace DistantEducation.Application.Models.Dto.StudyMaterial.AddNewMaterial;

public class MaterialRequestDto
{
    public string Name { get; set; }
    public string MaterialType { get; set; }
    public string CourseId { get; set; }

    public MaterialRequestDto(string name, string materialType, string courseId)
    {
        Name = name;
        MaterialType = materialType;
        CourseId = courseId;
    }
}