using CheckoutKata.Console.Factories;
using CheckoutKata.Console.Models;
using CheckoutKata.Console.Promotions;

namespace CheckoutKata.Console;

/// <summary>
/// A shopfront with a list of items, and the amount of said items the shop has in
/// stock at any given time.
/// </summary>
public sealed class Shop
{
    public List<IItem> Items { get; } = new();
    public List<IPromotion> Promotions { get; } = new();
    private readonly Dictionary<string, int> _itemQuantities = new();

    public Shop(ItemFactory itemFactory)
    {
        var items = itemFactory.CreateItems();
        foreach (var item in items)
        {
            AddItemToShop(item, 10);
        }
    }
    
    public void AddPromotion(IPromotion promotion) => Promotions.Add(promotion);

    public void RemovePromotion(IPromotion promotion) => Promotions.Remove(promotion);

    public void AddItemToShop(IItem item, int quantity)
    {
        Items.Add(item);
        _itemQuantities.Add(item.Sku, quantity);
    }

    public void RemoveItemFromShop(string itemSku)
    {
        if (_itemQuantities.ContainsKey(itemSku))
        {
            var item = Items.First(x => x.Sku == itemSku);
            Items.Remove(item);
            _itemQuantities.Remove(itemSku);
        }
    }

    /// <summary>
    /// Creates a new shopping session instance (with basket to add items to) for a user.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public ShoppingSession CreateShoppingSession(string userId) => new(userId, this);

    public int? GetItemQuantity(string itemSku)
    {
        if (_itemQuantities.ContainsKey(itemSku))
        {
            return _itemQuantities[itemSku];
        }

        return null;
    }

    public void SetItemQuantity(string itemSku, int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentException("Quantity cannot be less than 0.");
        }

        if (_itemQuantities.ContainsKey(itemSku))
        {
            _itemQuantities[itemSku] = quantity;
        }
    }
}