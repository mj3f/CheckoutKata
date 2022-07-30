using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Promotions;

public class HalfPricePromotion : IPromotion
{
    
    public double Discount { get; set; } = 2;
    public string ItemSku { get; set; }
    public int Quantity { get; }

    public double ApplyDiscount(double price)
    {
        return price / Discount;
    }
}