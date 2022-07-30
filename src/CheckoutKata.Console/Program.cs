using CheckoutKata.Console;
using CheckoutKata.Console.Factories;

var shop = new Shop(new ItemFactory());

string userId = "Mike";

var shoppingSession = shop.CreateShoppingSession(userId);


shoppingSession.AddToBasket("A", 4);
shoppingSession.RemoveFromBasket("A");
shoppingSession.AddToBasket("B", 2);

shoppingSession.Checkout();