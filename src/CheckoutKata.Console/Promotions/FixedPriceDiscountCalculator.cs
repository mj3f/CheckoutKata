namespace CheckoutKata.Console.Promotions;

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
        return 0;
    }
}