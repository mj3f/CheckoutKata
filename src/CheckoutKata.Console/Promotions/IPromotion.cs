using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Promotions;

public interface IPromotion
{
    double Discount { get; set; }
    
    string ItemSku { get; set; }
    
    int Quantity { get; }

    double ApplyDiscount(double price);
}