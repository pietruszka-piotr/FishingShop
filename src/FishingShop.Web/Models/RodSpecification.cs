namespace FishingShop.Web.Models;

public class RodSpecification
{
    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int LengthCm { get; set; }

    public decimal CastWeightMinG { get; set; }

    public decimal CastWeightMaxG { get; set; }

    public RodType Type { get; set; }
}
