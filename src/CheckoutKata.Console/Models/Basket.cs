namespace CheckoutKata.Console.Models;

public sealed class Basket
{
    /// <summary>
    /// Items in the basket. The key is the item Sku, value contains the item sku, quantity in the basket, and the
    /// total price.
    /// </summary>
    public Dictionary<string, BasketItem> Items { get; } = new();

    /// <summary>
    /// Adds an item to the basket, with its quantity (to add) and the total price
    /// (with discounts applied).
    /// </summary>
    /// <param name="item">item to add to the basket.</param>
    /// <param name="quantity">the number of times this item is added to the basket.</param>
    /// <param name="totalItemPrice">The price of this item multiplied by the quantity
    /// (with discounts applied if applicable)</param>
    public void AddItem(IItem item, int quantity, double totalItemPrice)
    {
        if (!Items.ContainsKey(item.Sku))
        {
            Items.Add(item.Sku, new BasketItem(item.Sku, quantity, totalItemPrice));
        }
        else
        {
            BasketItem basketItem = Items[item.Sku];
            basketItem.Quantity += quantity;
            basketItem.Price = totalItemPrice;
        }
    }

    /// <summary>
    /// Removes an item from the basket, given the quantity to remove specified.
    /// If the quantity subtracted from the existing quantity of this item already in the basket reaches 0,
    /// then the item is removed from the dictionary altogether.
    /// </summary>
    /// <param name="item">The item to be removed/reduced.</param>
    /// <param name="quantity">The number of times to remove this item from the basket by.</param>
    /// <param name="newPrice">The new price of the item(s) in the basket after removal.</param>
    public void RemoveItem(IItem item, int quantity, double newPrice)
    {
        if (Items.ContainsKey(item.Sku))
        {
            var basketItem = Items[item.Sku];
            basketItem.Quantity -= quantity;
            basketItem.Price = newPrice;

            if (basketItem.Quantity <= 0)
            {
                Items.Remove(item.Sku);
            }
        }
    }

    public double GetTotalPrice()
    {
        foreach (var item in Items.Values)
        {
            System.Console.WriteLine($"ITEM {item.ItemSku}, price = {item.Price}, quantity = {item.Quantity}");
            System.Console.WriteLine("-----------------------------");
        }
        return Items.Values.Select(x => x.Price).Sum();
    }
}