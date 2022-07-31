namespace CheckoutKata.Console.Models;

public sealed class Basket
{
    public double TotalPrice { get; set; }

    private readonly Dictionary<string, BasketItem> _items = new();

    public void AddItem(IItem item, int quantity, double totalItemPrice)
    {
        if (!_items.ContainsKey(item.Sku))
        {
            _items.Add(item.Sku, new BasketItem(item.Sku, quantity, totalItemPrice));
        }
        else
        {
            BasketItem basketItem = _items[item.Sku];
            basketItem.Quantity += quantity;
            basketItem.Price = totalItemPrice;
        }
    }

    public void RemoveItem(IItem item, int quantity, double newPrice)
    {
        if (_items.ContainsKey(item.Sku))
        {
            var basketItem = _items[item.Sku];
            basketItem.Quantity -= quantity;
            basketItem.Price -= newPrice;

            if (basketItem.Quantity <= 0)
            {
                _items.Remove(item.Sku);
            }
        }
    }

    public double GetTotalPrice()
    {
        foreach (var item in _items.Values)
        {
            System.Console.WriteLine($"ITEM {item.ItemSku}, price = {item.Price}, quantity = {item.Quantity}");
            System.Console.WriteLine("-----------------------------");
        }
        return _items.Values.Select(x => x.Price).Sum();
    }
}