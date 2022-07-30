namespace CheckoutKata.Console.Models;

public class Item : IItem
{
    public string Sku { get; set; }

    public double Price { get; set; }
}