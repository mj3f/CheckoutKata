using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Promotions;

public class ItemPromotion : IPromotion
{
    public string Id { get; init; }
    public string ItemSku { get; }
    public IDiscountCalculator DiscountCalculator { get; }

    public ItemPromotion(string itemSku, IDiscountCalculator discountCalculator)
    {
        ItemSku = itemSku;
        DiscountCalculator = discountCalculator;
        Id = Guid.NewGuid().ToString();
    }

    public double ApplyDiscount(double itemPrice, int itemQuantity)
    {
        return DiscountCalculator.CalculateItemDiscount(itemPrice, itemQuantity);
    }
}