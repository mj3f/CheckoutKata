namespace CheckoutKata.Console.Models;

public interface IItem
{
    string Sku { get; set; }
    
    double Price { get; set; }
}