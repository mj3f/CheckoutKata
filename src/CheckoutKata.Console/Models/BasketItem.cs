namespace CheckoutKata.Console.Models;

public class BasketItem
{
    public string ItemSku { get; set; }
    
    public int Quantity { get; set; }
    
    public double Price { get; set; }

    public BasketItem(string itemSku, int quantity, double price)
    {
        ItemSku = itemSku;
        Quantity = quantity;
        Price = price;
    }
}