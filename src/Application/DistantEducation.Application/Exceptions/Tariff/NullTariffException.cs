namespace DistantEducation.Application.Exceptions.Tariff;

public class NullTariffException : Exception
{
    public NullTariffException()
    {
    }

    public NullTariffException(string message) : base(message)
    {
    }
}