namespace CheckoutKata.Console.Models;

public sealed class Basket
{
    public double TotalPrice { get; set; }

    private readonly Dictionary<string, BasketItem> _items = new();

    public void AddItem(IItem item)
    {
        if (!_items.ContainsKey(item.Sku))
        {
            _items.Add(item.Sku, new BasketItem(item.Sku, 1, item.Price));
        }
        else
        {
            BasketItem basketItem = _items[item.Sku];
            basketItem.Quantity += 1;
            basketItem.TotalPrice += item.Price;
        }
    }

    public void RemoveItem(IItem item)
    {
        if (_items.ContainsKey(item.Sku))
        {
            _items.Remove(item.Sku);
        }
    }
    
    // private double CalculatePrice()
    // {
    //     if (_items.Count == 0)
    //     {
    //         return 0;
    //     }
    //
    //     return _items.Select(x => x.Price).Sum();
    // }
}