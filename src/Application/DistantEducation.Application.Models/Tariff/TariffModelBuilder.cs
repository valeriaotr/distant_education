namespace DistantEducation.Application.Models.Tariff;

public class TariffModelBuilder
{
    private string _id;
    private string? _name;
    private int _price;
    private int _validity;

    public TariffModelBuilder Id(string id)
    {
        _id = id;
        return this;
    }

    public TariffModelBuilder Name(string? name)
    {
        _name = name;
        return this;
    }

    public TariffModelBuilder Price(int price)
    {
        _price = price;
        return this;
    }

    public TariffModelBuilder Validity(int validity)
    {
        _validity = validity;
        return this;
    }

    public TariffModel Build()
    {
        return new TariffModel(_id, _name, _price, _validity);
    }
}