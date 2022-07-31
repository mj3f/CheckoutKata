using CheckoutKata.Console.Models;
using CheckoutKata.Console.Promotions;

namespace CheckoutKata.Console;

public sealed class ShoppingSession
{
    private readonly Basket _basket = new();
    private readonly string _userId;
    private readonly Shop _shop;

    public ShoppingSession(string userId, Shop shop)
    {
        _userId = userId;
        _shop = shop;
    }

    /// <summary>
    /// Adds an item to the basket and calculates its price.
    /// </summary>
    /// <param name="itemSku"></param>
    /// <param name="quantity"></param>
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
            System.Console.WriteLine($"Price for item {item.Sku} is {price}, with quantity {itemQuantity}.");
        }
    }
    
    /// <summary>
    /// Removes an item from the basket, re-calculates the price for the item based on the quantity
    /// remaining in the basket (if any).
    /// </summary>
    /// <param name="itemSku"></param>
    /// <param name="quantity"></param>
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
            System.Console.WriteLine($"Price for item {item.Sku} is {price}, with quantity {itemQuantity}");
        }
    }

    /// <summary>
    /// Gets the total price of all the items in the basket.
    /// </summary>
    public double Checkout()
    {
        return _basket.GetTotalPrice();
    }

    /// <summary>
    /// Calculates the price for an item added/removed to a basket, based on the quantity.
    /// </summary>
    /// <param name="item">The item to be inserted/removed from the basket.</param>
    /// <param name="quantity">the number of times the item is to be added/removed from the basket.</param>
    /// <returns>The price of adding an item n times to the basket.</returns>
    private double CalculatePriceForItems(IItem item, int quantity)
    {
        double price = item.Price * quantity; // Any applicable promotions found will overwrite this result by design.
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