namespace DistantEducation.Application.Models.Tariff;

public class TariffModel
{
    private string Id { get; set; }
    private string? Name { get; set; }
    private int Price { get; set; }
    private int Validity { get; set; }

    public TariffModel(string id, string? name, int price, int validity)
    {
        Id = id;
        Name = name;
        Price = price;
        Validity = validity;
    }

    public static TariffModelBuilder Builder()
    {
        return new TariffModelBuilder();
    }

    public string GetId()
    {
        return Id;
    }

    public string? GetName()
    {
        return Name;
    }

    public int GetPrice()
    {
        return Price;
    }

    public int GetValidity()
    {
        return Validity;
    }
}