namespace DistantEducation.Application.Models.Dto.StudyMaterial.UpdateMaterialInfo;

public class UpdateStudyMaterialTypeRequestDto
{
    public string MaterialId { get; set; }
    public string MaterialType { get; set; }

    public UpdateStudyMaterialTypeRequestDto(string materialId, string materialType)
    {
        MaterialType = materialType;
        MaterialId = materialId;
    }
}