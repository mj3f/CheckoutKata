namespace CheckoutKata.Console.Promotions;

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