namespace DistantEducation.Application.Exceptions;

public class NullCourseException : Exception
{
    public NullCourseException()
    {
    }

    public NullCourseException(string message) : base(message)
    {
    }
}