namespace CheckoutKata.Console.Promotions;

/// <summary>
/// Applies a discount as a percentage of the value of each item.
/// E.g. if Discount is 2, then each item will be divided by 2, effectively 50% of the items unit price.
/// </summary>
public class PercentageDiscountCalculator : IDiscountCalculator
{
    public int MinQuantity { get; }
    
    public double Discount { get; }
    
    public PercentageDiscountCalculator(double discount, int minQuantity)
    {
        Discount = discount;
        MinQuantity = minQuantity;
    }

    public double CalculateItemDiscount(double itemPrice, int itemQuantity)
    {
        double price = 0;

        var numberOfTimesToApplyDiscount = Math.Floor((double)(itemQuantity / MinQuantity));

        for (var i = 0; i < numberOfTimesToApplyDiscount; i++)
        {
            price += (itemPrice / Discount) * MinQuantity;
        }
        
        var remainder = itemQuantity % MinQuantity; // items where discount does not apply (itemQuantity % MinQuantity != 0)
        for (var i = 0; i < remainder; i++)
        {
            price += itemPrice;
        }

        return price;
    }
}