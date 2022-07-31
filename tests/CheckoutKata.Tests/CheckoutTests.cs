using CheckoutKata.Console;
using CheckoutKata.Console.Factories;
using CheckoutKata.Console.Promotions;
using FluentAssertions;

namespace CheckoutKata.Tests;

public class CheckoutTests
{
    private readonly ItemFactory _itemFactory;
    private readonly Shop _shop;
    
    public CheckoutTests()
    {
        _itemFactory = new ItemFactory();
        _shop = new Shop(_itemFactory);
    }

    [Fact]
    public void PriceForItemD_ShouldBe25PercentOffForEvery2ItemsAdded()
    {
        _shop.AddPromotion(new ItemPromotion("D", new PercentageDiscountCalculator(4, 2)));

        var userShoppingSession = _shop.CreateShoppingSession("test-user");
        
        userShoppingSession.AddToBasket("D", 2);
        
        double finalPrice = userShoppingSession.Checkout();

        var itemD = _itemFactory.CreateItemD();

        var calculationTestedResult = (itemD.Price / 4) * 2;
        finalPrice.Should().Be(calculationTestedResult);
    }
    
    [Fact]
    public void PriceForItemD_ShouldBe55_When4ItemsAdded()
    {
        _shop.AddPromotion(new ItemPromotion("D", new PercentageDiscountCalculator(4, 2)));

        var userShoppingSession = _shop.CreateShoppingSession("test-user");
        
        userShoppingSession.AddToBasket("D", 4);
        
        double finalPrice = userShoppingSession.Checkout();

        var itemD = _itemFactory.CreateItemD();

        var calculationTestedResult = itemD.Price / 4 * 2 * 2; // 55
        finalPrice.Should().Be(calculationTestedResult);
    }
    
    [Fact]
    public void PriceForItemD_ShouldBe110_When5ItemsAdded()
    {
        _shop.AddPromotion(new ItemPromotion("D", new PercentageDiscountCalculator(4, 2)));

        var userShoppingSession = _shop.CreateShoppingSession("test-user");
        
        userShoppingSession.AddToBasket("D", 5);
        
        double finalPrice = userShoppingSession.Checkout();
        
        // itemD.Price / 4 * 2 * 2 + itemD.Price; // 110
        finalPrice.Should().Be(110);
    }
    
    [Fact]
    public void PriceForItemB_ShouldBe40_When3ItemsAdded()
    {
        _shop.AddPromotion(new ItemPromotion("B", new FixedPriceDiscountCalculator(40, 3)));

        var userShoppingSession = _shop.CreateShoppingSession("test-user");
        
        userShoppingSession.AddToBasket("B", 3);
        
        double finalPrice = userShoppingSession.Checkout();

        finalPrice.Should().Be(40);
    }
    
    [Fact]
    public void PriceForItemB_ShouldBe55_When4ItemsAdded()
    {
        _shop.AddPromotion(new ItemPromotion("B", new FixedPriceDiscountCalculator(40, 3)));

        var userShoppingSession = _shop.CreateShoppingSession("test-user");
        
        userShoppingSession.AddToBasket("B", 4);
        
        double finalPrice = userShoppingSession.Checkout();

        finalPrice.Should().Be(55);
    }

    [Fact]
    public void PriceForItemA_ShouldBe60_When6ItemsAdded()
    {
        var userShoppingSession = _shop.CreateShoppingSession("test-user");
        
        userShoppingSession.AddToBasket("A", 6);
        
        double finalPrice = userShoppingSession.Checkout();

        finalPrice.Should().Be(60);
    }
    
    [Fact]
    public void PriceForItemA_ShouldBe30_When6ItemsAdded_With50PercentDiscountPromotionApplied()
    {
        _shop.AddPromotion(new ItemPromotion("A", new PercentageDiscountCalculator(2, 3)));
        var userShoppingSession = _shop.CreateShoppingSession("test-user");
        
        userShoppingSession.AddToBasket("A", 6);
        
        double finalPrice = userShoppingSession.Checkout();

        finalPrice.Should().Be(30);
    }
}