namespace CheckoutKata.Console.Promotions;

/// <summary>
/// Calculates the discount to be applied to an item.
/// </summary>
public interface IDiscountCalculator
{
    /// <summary>
    /// The minimum quantity before the discount is applied.
    /// </summary>
    int MinQuantity { get; }
    
    /// <summary>
    /// The discount amount.
    /// </summary>
    double Discount { get; }

    /// <summary>
    /// Takes an items unit price, and the number of items and calculates the final price
    /// for n items when added to a basket.
    /// </summary>
    /// <param name="itemPrice"></param>
    /// <param name="itemQuantity"></param>
    /// <returns>The price for the n items (of the same type) in a basket.</returns>
    double CalculateItemDiscount(double itemPrice, int itemQuantity);
}