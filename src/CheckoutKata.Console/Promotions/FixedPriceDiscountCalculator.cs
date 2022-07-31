namespace CheckoutKata.Console.Promotions;

/// <summary>
/// Applies the discount as a fixed price given the quantity.
/// E.g. if the promotion is 3 for 40, for every 3 quantity items passed in,
/// the fixed price of 40 will be applied.
/// </summary>
public class FixedPriceDiscountCalculator : IDiscountCalculator
{
    public int MinQuantity { get; }
    
    public double Discount { get; }
    
    public FixedPriceDiscountCalculator(double discount, int minQuantity)
    {
        Discount = discount;
        MinQuantity = minQuantity;
    }

    public double CalculateItemDiscount(double itemPrice, int itemQuantity)
    {
        double price = 0;
        double numberOfTimesToApplyDiscount = Math.Floor((double)(itemQuantity / MinQuantity));

        if (numberOfTimesToApplyDiscount > 0)
        {
            price = Discount * numberOfTimesToApplyDiscount;
        }

        int remainder = itemQuantity % MinQuantity; // for items where discount does not apply (itemQuantity % MinQuantity != 0)
        for (var i = 0; i < remainder; i++)
        {
            price += itemPrice;
        }
        
        return price;
    }
}