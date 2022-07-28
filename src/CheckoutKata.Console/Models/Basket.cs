namespace CheckoutKata.Console.Models;

public sealed class Basket
{
    public double TotalPrice { get; set; }

    private List<Item> _items { get; set; } = new();
    
}