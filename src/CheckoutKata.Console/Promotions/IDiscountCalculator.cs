namespace CheckoutKata.Console.Promotions;

public interface IDiscountCalculator
{
    int MinQuantity { get; }
    double Discount { get; }

    double CalculateItemDiscount(double itemPrice, int itemQuantity);
}