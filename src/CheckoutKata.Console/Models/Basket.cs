namespace CheckoutKata.Console.Models;

public sealed class Basket
{
    public Dictionary<string, BasketItem> Items { get; } = new();

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