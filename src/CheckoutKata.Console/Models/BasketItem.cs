namespace CheckoutKata.Console.Models;

public class BasketItem
{
    /// <summary>
    /// Unique identifier of the item.
    /// </summary>
    public string ItemSku { get; }
    
    /// <summary>
    /// Number of times the item is in the basket.
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// The cose of n items in the basket.
    /// </summary>
    public double Price { get; set; }

    public BasketItem(string itemSku, int quantity, double price)
    {
        ItemSku = itemSku;
        Quantity = quantity;
        Price = price;
    }
}