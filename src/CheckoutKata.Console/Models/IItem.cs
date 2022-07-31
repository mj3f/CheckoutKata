namespace CheckoutKata.Console.Models;

public interface IItem
{
    /// <summary>
    /// The unique identifier of the product.
    /// </summary>
    string Sku { get; set; }
    
    /// <summary>
    /// The unit price of this single item.
    /// </summary>
    double Price { get; set; }
}