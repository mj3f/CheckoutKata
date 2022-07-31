using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Promotions;

public interface IPromotion
{
    string ItemSku { get; }
    
    IDiscountCalculator DiscountCalculator { get; }

    double ApplyDiscount(double itemPrice, int itemQuantity);
}