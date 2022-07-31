using System.Runtime.InteropServices;
using CheckoutKata.Console;
using CheckoutKata.Console.Factories;
using CheckoutKata.Console.Models;
using CheckoutKata.Console.Promotions;
using FluentAssertions;

namespace CheckoutKata.Tests.ShoppingTests;

public class ShopTests
{
    private Shop _sut;

    public ShopTests()
    {
        _sut = new Shop(new ItemFactory());
    }

    [Fact]
    public void AddPromotion_ShouldAddPromotion_WhenPromotionProvided()
    {
        var promotion = new ItemPromotion("Test", new PercentageDiscountCalculator(1, 1));
        _sut.AddPromotion(promotion);

        _sut.Promotions.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void AddPromotion_ShouldNotAddPromotion_WhenNoSkuIsProvided()
    {
        var promotion = new ItemPromotion("", new PercentageDiscountCalculator(1, 1));
        _sut.AddPromotion(promotion);

        _sut.Promotions.Should().BeEmpty();   
    }

    [Fact]
    public void RemovePromotion_ShouldRemovePromotion_WhenIdProvidedMatchesPromotionInList()
    {

        var promotion = new ItemPromotion("ABC", new PercentageDiscountCalculator(1, 1));
        _sut.AddPromotion(promotion);

        string id = promotion.Id;

        _sut.RemovePromotion(id);

        _sut.Promotions.Should().BeEmpty();
    }
    
    [Fact]
    public void RemovePromotion_ShouldNotRemovePromotion_WhenIdProvidedDoesNotMatchPromotionInList()
    {

        var promotion = new ItemPromotion("ABC", new PercentageDiscountCalculator(1, 1));
        _sut.AddPromotion(promotion);

        string id = "HelloTesting";

        _sut.RemovePromotion(id);

        _sut.Promotions.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void AddItemToShop_ShouldAddItemToShop_WhenItemAndQuantityProvided()
    {
        var item = new Item
        {
            Price = 0,
            Sku = "Test"
        };
        _sut.AddItemToShop(item, 1);

        _sut.Items.Should().Contain(item);
    }
    
    [Theory]
    [InlineData("", 1)]
    [InlineData("", 0)]
    [InlineData("test", 0)]
    [InlineData(null, 23)]
    [InlineData(null, 0)]
    public void AddItemToShop_ShouldNotAddItemToShop_WhenItemSkuIsNotProvidedOrQuantityNotProvided(string sku, int quantity)
    {
        var item = new Item
        {
            Price = 0,
            Sku = sku
        };
        _sut.AddItemToShop(item, quantity);

        _sut.Items.Should().NotContain(item);
    }

    [Fact]
    public void SetItemQuantity_ShouldIncreaseQuantity_WhenItemSkuAndPositiveQuantityProvided()
    {
        var item = new Item
        {
            Price = 0,
            Sku = "test"
        };
        _sut.AddItemToShop(item, 1);
        _sut.SetItemQuantity(item.Sku, 12);

        _sut.GetItemQuantity(item.Sku).Should().Be(12);
    }
    
    [Fact]
    public void SetItemQuantity_ShouldNotIncreaseQuantity_WhenItemDoesNotExist()
    {
        string sku = "testywesty";
        _sut.SetItemQuantity(sku, 12);

        _sut.GetItemQuantity(sku).Should().BeNull();
    }
    
    [Fact]
    public void SetItemQuantity_ShouldNotChangeQuantity_WhenNegativeQuantityProvided()
    {
        var item = new Item
        {
            Price = 0,
            Sku = "test"
        };
        _sut.AddItemToShop(item, 5);
        
        _sut.SetItemQuantity(item.Sku, -3);

        _sut.GetItemQuantity(item.Sku).Should().Be(5);
    }
}