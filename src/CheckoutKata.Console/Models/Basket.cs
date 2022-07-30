namespace CheckoutKata.Console.Models;

public sealed class Basket
{
    public double TotalPrice { get; set; }

    private readonly Dictionary<string, BasketItem> _items = new();

    public void AddItem(IItem item, int quantity)
    {
        if (!_items.ContainsKey(item.Sku))
        {
            _items.Add(item.Sku, new BasketItem(item.Sku, quantity, item.Price));
        }
        else
        {
            BasketItem basketItem = _items[item.Sku];
            basketItem.Quantity += quantity;
        }
    }

    public void RemoveItem(IItem item, int quantity)
    {
        if (_items.ContainsKey(item.Sku))
        {
            var basketItem = _items[item.Sku];
            basketItem.Quantity -= quantity;

            if (basketItem.Quantity <= 0)
            {
                _items.Remove(item.Sku);
            }
        }
    }

    public double CalculateTotalPrice()
    {
        TotalPrice = _items.Values.Select(x => x.Price * x.Quantity).Sum();
        var itmes = _items.Values;
        foreach (var itme in itmes)
        {
            System.Console.WriteLine($"Basket contents: Sku: {itme.ItemSku}, Quantity: {itme.Quantity}, Price: {itme.Price}");
        }
        
        return TotalPrice;
    }
}