using CheckoutKata.Console.Factories;
using CheckoutKata.Console.Models;
using CheckoutKata.Console.Promotions;

namespace CheckoutKata.Console;

/// <summary>
/// A shopfront with a list of items, and the amount of said items the shop has in
/// stock at any given time.
/// </summary>
public class Shop
{
    public List<IItem> Items { get; }
    private List<IPromotion> _promotions = new();
    private Dictionary<string, int> _itemQuantities = new();
    private readonly ItemFactory _itemFactory;

    public Shop(ItemFactory itemFactory)
    {
        AddItemToShop(itemFactory.CreateItemA(), 10);
        AddItemToShop(itemFactory.CreateItemB(), 10);
        AddItemToShop(itemFactory.CreateItemC(), 10);
        AddItemToShop(itemFactory.CreateItemD(), 10);
    }
    
    public void AddPromotion(IPromotion promotion) => _promotions.Add(promotion);

    public void RemovePromotion(IPromotion promotion) => _promotions.Remove(promotion);

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