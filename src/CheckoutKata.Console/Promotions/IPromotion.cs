using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Promotions;

/// <summary>
/// Defines a promotion that can be applied to an item, which discounts its price.
/// </summary>
public interface IPromotion
{
    /// <summary>
    /// The unique identifier of the item that the promotion applies to.
    /// </summary>
    string ItemSku { get; }
    
    /// <summary>
    /// The object which calculates the discount of n items as part of this promotion.
    /// </summary>
    IDiscountCalculator DiscountCalculator { get; }

    /// <summary>
    /// Calls the discount calculator to apply the discounted price of an item.
    /// </summary>
    /// <param name="itemPrice"></param>
    /// <param name="itemQuantity"></param>
    /// <returns></returns>
    double ApplyDiscount(double itemPrice, int itemQuantity);
}