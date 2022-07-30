using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Promotions;

public class NItemsForFixedPricePromotion : IPromotion
{
    public double Discount { get; set; }
    public string ItemSku { get; set; }
    public int Quantity { get; }

    public double ApplyDiscount(double price)
    {
        // ????
        return price;
    }
}