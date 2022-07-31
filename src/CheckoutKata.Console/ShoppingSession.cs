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

    public void AddToBasket(string itemSku, int quantity = 1) // TODO: Apply any promotions in here.
    {
        IItem? item = _shop.Items.FirstOrDefault(x => x.Sku == itemSku);

        if (item is not null)
        {
            var price = CalculatePrice(item, quantity);
            
            
            _basket.AddItem(item, quantity);
            int shopItemStock = (int) _shop.GetItemQuantity(itemSku)!;
            _shop.SetItemQuantity(itemSku, shopItemStock - quantity);
            System.Console.WriteLine($"{_userId} Has added item {item.Sku} to their basket with quantity {quantity}.");
        }
    }

    public void RemoveFromBasket(string itemSku, int quantity = 1)
    {
        IItem? item = _shop.Items.FirstOrDefault(x => x.Sku == itemSku);

        if (item is not null)
        {
            _basket.RemoveItem(item, quantity);
            int shopItemStock = (int) _shop.GetItemQuantity(itemSku)!;
            _shop.SetItemQuantity(itemSku, shopItemStock + quantity);
            System.Console.WriteLine($"{_userId} Has removed item {item.Sku} from their basket with quantity {quantity}.");
        }
    }

    public void Checkout()
    {
        double priceToPay = _basket.CalculateTotalPrice();
        System.Console.WriteLine($"Total price to pay for user {_userId} is {priceToPay}");
    }

    private double CalculatePrice(IItem item, int quantity)
    {
        double price = 0; // item.Price * quantity;
        foreach (var promotion in _shop.Promotions)
        {
            if (promotion.ItemSku == item.Sku)
            {
                price = promotion.ApplyDiscount(item.Price, quantity);
            }
        }

        return price;
    }
}