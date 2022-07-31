using CheckoutKata.Console;
using CheckoutKata.Console.Factories;
using CheckoutKata.Console.Promotions;

var shop = new Shop(new ItemFactory());
shop.AddPromotion(new ItemPromotion("A", new PercentageDiscountCalculator(2, 3)));
shop.AddPromotion(new ItemPromotion("B", new FixedPriceDiscountCalculator(40, 3)));

string userId = "Mike";

var shoppingSession = shop.CreateShoppingSession(userId);


shoppingSession.AddToBasket("A", 5);
shoppingSession.RemoveFromBasket("A");
// shoppingSession.AddToBasket("A", 6);
shoppingSession.AddToBasket("B", 3);

shoppingSession.Checkout();

shoppingSession.RemoveFromBasket("A");

shoppingSession.Checkout();