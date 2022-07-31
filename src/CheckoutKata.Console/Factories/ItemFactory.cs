using CheckoutKata.Console.Models;

namespace CheckoutKata.Console.Factories;

/// <summary>
/// Factory to create a set of Items as defined in the kata spec.
/// This allows us to ensure that each time item X is created, it will have the same Sku and unit price.
/// </summary>
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

    /// <summary>
    /// Return a list of pre-determined items to a shop.
    /// </summary>
    /// <returns></returns>
    public List<IItem> CreateItems() => new()
    {
        CreateItemA(),
        CreateItemB(),
        CreateItemC(),
        CreateItemD()
    };
}