using CheckoutKata.Console;
using CheckoutKata.Console.Factories;
using CheckoutKata.Console.Models;
using CheckoutKata.Console.Promotions;

var shop = new Shop(new ItemFactory());

string userId = "Mike";

var shoppingSession = shop.CreateShoppingSession(userId);


shoppingSession.AddToBasket("A");
shoppingSession.RemoveFromBasket("A");