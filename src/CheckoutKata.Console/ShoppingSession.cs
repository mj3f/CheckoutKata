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

    public void AddToBasket(string itemSku, int quantity = 1)
    {
        IItem? item = _shop.Items.FirstOrDefault(x => x.Sku == itemSku);

        if (item is not null)
        {
            System.Console.WriteLine($"Adding item {itemSku} from basket, quantity to add = {quantity}");

            int shopItemStock = (int) _shop.GetItemQuantity(itemSku)!;
            if (shopItemStock - quantity < 0)
            {
                System.Console.WriteLine("quantity of items to add to basket exceeds shop stock!");
                return;
            }
            
            int itemQuantity = GetExistingItemInBasketQuantity(itemSku) + quantity;
            var price = CalculatePriceForItems(item, itemQuantity);
            _basket.AddItem(item, quantity, price);
            _shop.SetItemQuantity(itemSku, shopItemStock - quantity);
            System.Console.WriteLine($"Price for item {item.Sku}, with quantity {itemQuantity} is {price}");
        }
    }

    public void RemoveFromBasket(string itemSku, int quantity = 1)
    {
        IItem? item = _shop.Items.FirstOrDefault(x => x.Sku == itemSku);

        if (item is not null)
        {
            System.Console.WriteLine($"Removing item {itemSku} from basket, quantity to remove = {quantity}");
            int shopItemStock = (int) _shop.GetItemQuantity(itemSku)!;
            _shop.SetItemQuantity(itemSku, shopItemStock + quantity);

            int itemQuantity = GetExistingItemInBasketQuantity(itemSku) - quantity;
            var price = CalculatePriceForItems(item, itemQuantity);
            _basket.RemoveItem(item, quantity, price);
            System.Console.WriteLine($"Price for item {item.Sku}, with quantity {itemQuantity} is {price}");

        }
    }

    public void Checkout()
    {
        double priceToPay = _basket.GetTotalPrice();
        System.Console.WriteLine($"Total price to pay for user {_userId} is {priceToPay}");
    }

    private double CalculatePriceForItems(IItem item, int quantity)
    {
        double price = item.Price * quantity;
        foreach (var promotion in _shop.Promotions)
        {
            if (promotion.ItemSku == item.Sku)
            {
                price = promotion.ApplyDiscount(item.Price, quantity);
            }
        }

        return price;
    }

    /// <summary>
    /// Returns the quantity of the item with item sku in the basket.
    /// If the item is not in the basket, return 0 quantity.
    /// </summary>
    /// <param name="itemSku"></param>
    /// <returns></returns>
    private int GetExistingItemInBasketQuantity(string itemSku) =>
        _basket.Items.ContainsKey(itemSku) ? _basket.Items[itemSku].Quantity : 0;
}