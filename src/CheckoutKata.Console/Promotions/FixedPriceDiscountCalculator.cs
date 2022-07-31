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
        double price = 0;
        double times = Math.Floor((double)(itemQuantity / MinQuantity));

        if (times > 0)
        {
            price = Discount * times;
        }

        int remainder = itemQuantity % MinQuantity;
        for (var i = 0; i < remainder; i++)
        {
            price += itemPrice;
        }
        
        return price;
    }
}