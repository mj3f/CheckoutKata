using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Promotions;

public class ItemPromotion : IPromotion
{
    public string ItemSku { get; }
    public IDiscountCalculator DiscountCalculator { get; }

    public ItemPromotion(string itemSku, IDiscountCalculator discountCalculator)
    {
        ItemSku = itemSku;
        DiscountCalculator = discountCalculator;
    }

    public double ApplyDiscount(double itemPrice, int itemQuantity)
    {
        return DiscountCalculator.CalculateItemDiscount(itemPrice, itemQuantity);
    }
}