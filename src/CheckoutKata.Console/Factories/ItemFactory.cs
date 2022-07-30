using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Factories;

public class ItemFactory
{
    public IItem CreateItemA() => new Item
    {
        Sku = "A",
        Price = 10
    };
    
    public IItem CreateItemB() => new Item
    {
        Sku = "B",
        Price = 15
    };

    public IItem CreateItemC() => new Item
    {
        Sku = "C",
        Price = 40
    };

    public IItem CreateItemD() => new Item
    {
        Sku = "D",
        Price = 55
    };
}