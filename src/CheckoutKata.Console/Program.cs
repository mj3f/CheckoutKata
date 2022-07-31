using CheckoutKata.Console;
using CheckoutKata.Console.Factories;
using CheckoutKata.Console.Promotions;

var shop = new Shop(new ItemFactory());
shop.AddPromotion(new ItemPromotion("B", new FixedPriceDiscountCalculator(40, 3)));
shop.AddPromotion(new ItemPromotion("D", new PercentageDiscountCalculator(4, 2)));

string user = "User";

var userShoppingSession = shop.CreateShoppingSession(user);

// Play around with adding and removing items to the basket (note that for adding/removing items to the basket
// default quantity is 1 if not explicitly specified in either AddToBasket or RemoveFromBasket methods.
userShoppingSession.AddToBasket("B", 3);
userShoppingSession.AddToBasket("D", 5);
userShoppingSession.RemoveFromBasket("D");
userShoppingSession.RemoveFromBasket("B", 2);

// Get final price of items in the basket.
double finalPrice = userShoppingSession.Checkout();
Console.WriteLine($"Final price to pay for all items in the basket = {finalPrice}");