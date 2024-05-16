namespace DistantEducation.Application.Models.Dto.StudyMaterial.UpdateMaterialInfo;

public class UpdateStudyMaterialNameRequestDto
{
    public string MaterialId { get; set; }
    public string NewName { get; set; }

    public UpdateStudyMaterialNameRequestDto(string materialId, string newName)
    {
        MaterialId = materialId;
        NewName = newName;
    }
}