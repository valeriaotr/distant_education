namespace DistantEducation.Application.Exceptions;

public class NullStatisticsException : Exception
{
    public NullStatisticsException()
    {
    }

    public NullStatisticsException(string message) : base(message)
    {
    }
}