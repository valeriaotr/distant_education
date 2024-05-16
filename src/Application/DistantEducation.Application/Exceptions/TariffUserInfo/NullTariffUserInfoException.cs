namespace DistantEducation.Application.Exceptions.TariffUserInfo;

public class NullTariffUserInfoException : Exception
{
    public NullTariffUserInfoException()
    {
    }

    public NullTariffUserInfoException(string message) : base(message)
    {
    }
}