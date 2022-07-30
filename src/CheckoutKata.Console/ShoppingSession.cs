using CheckoutKata.Console.Models;
using CheckoutKata.Console.Promotions;

namespace CheckoutKata.Console;

public class ShoppingSession
{
    private readonly Basket _basket = new();
    private readonly string _userId;
    private readonly Shop _shop;

    public ShoppingSession(string userId, Shop shop)
    {
        _userId = userId;
        _shop = shop;
    }

    public void AddToBasket(string itemSku) // TODO: Apply any promotions in here.
    {
        IItem? item = _shop.Items.FirstOrDefault(x => x.Sku == itemSku);

        if (item is not null)
        {
            _basket.AddItem(item);
            int quantity = (int) _shop.GetItemQuantity(itemSku)!;
            _shop.SetItemQuantity(itemSku, quantity - 1);
        }
    }

    public void RemoveFromBasket(string itemSku)
    {
        IItem? item = _shop.Items.FirstOrDefault(x => x.Sku == itemSku);

        if (item is not null)
        {
            _basket.RemoveItem(item);
            int quantity = (int) _shop.GetItemQuantity(itemSku)!;
            _shop.SetItemQuantity(itemSku, quantity + 1);
        }
    }

    public void Checkout()
    {
        
    }
}