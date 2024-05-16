namespace DistantEducation.Application.Exceptions.StudyMaterial;

public class NullStudyMaterialException : Exception
{
    public NullStudyMaterialException ()
    {
    }

    public NullStudyMaterialException (string message) : base(message)
    {
    }
}