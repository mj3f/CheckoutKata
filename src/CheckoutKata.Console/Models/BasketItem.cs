namespace CheckoutKata.Console.Models;

public class BasketItem
{
    public string ItemSku { get; set; }
    
    public int Quantity { get; set; }
    
    public double TotalPrice { get; set; }

    public BasketItem(string itemSku, int quantity, double price)
    {
        ItemSku = itemSku;
        Quantity = quantity;
        TotalPrice = price;
    }
}