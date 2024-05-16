namespace DistantEducation.Application.Exceptions;

public class EmptyStudyMaterialsListException : Exception
{
    public EmptyStudyMaterialsListException()
    {
    }

    public EmptyStudyMaterialsListException(string message) : base(message)
    {
    }
}