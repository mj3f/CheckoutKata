using CheckoutKata.Console;
using CheckoutKata.Console.Factories;
using FluentAssertions;

namespace CheckoutKata.Tests.ShoppingTests;

public class ShoppingSessionTests
{
    private readonly Shop _shop;
    private readonly ShoppingSession _sut;

    public ShoppingSessionTests()
    {
        // Use real object instead of mocking to access pre-populated shop Items.
        _shop = new Shop(new ItemFactory());
        _sut = new ShoppingSession("TEST_USER", _shop);
    }

    [Fact]
    public void AddToBasket_ShouldAddItemToBasket_WhenItemSkuProvided()
    {
        var sku = "A"; // Item A already inserted in the Shops items - see constructor.
        var item = _shop.Items.First(x => x.Sku == sku);
        
        _sut.AddToBasket(sku); // quantity not provided, defaults to 1.

        // Roundabout way of testing if the item was inserted, if it was then price should be equal to
        // Item A price with quantity 1. (Alternative is making basket object public, which I don't want to do.
        double price = _sut.Checkout();

        price.Should().Be(item.Price);

    }
    
    [Fact]
    public void AddToBasket_ShouldNotAddItemToBasket_WhenItemSkuDoesNotMatchItemInShop()
    {
        var sku = "INVALID"; // Item A already inserted in the Shops items - see constructor.
        _sut.AddToBasket(sku); // quantity not provided, defaults to 1.

        // Roundabout way of testing if the item was inserted,
        // (Alternative is making basket object public, which I don't want to do.)
        double price = _sut.Checkout();

        price.Should().Be(0);

    }
    
    [Fact]
    public void AddToBasket_ShouldNotAddItemToBasket_WhenQuantityOfShopItemsWillBecomeLessThanZero()
    {
        var sku = "A"; // Item A already inserted in the Shops items - see constructor.

        _sut.AddToBasket(sku, 11); // Assuming in shop, ItemA is added 10 times.

        // Roundabout way of testing if the item was inserted,
        // (Alternative is making basket object public, which I don't want to do.)
        double price = _sut.Checkout();

        price.Should().Be(0);
    }

    [Fact]
    public void RemoveFromBasket_ShouldRemoveItemFromBasket_WhenItemExists()
    {
        var sku = "A"; // Item A already inserted in the Shops items - see constructor.
        var item = _shop.Items.First(x => x.Sku == sku);
        
        _sut.AddToBasket(sku, 1); // Assuming in shop, ItemA is added 10 times.

        // Roundabout way of testing if the item was inserted,
        // (Alternative is making basket object public, which I don't want to do.)
        double price = _sut.Checkout();

        price.Should().Be(item.Price);
        
        _sut.RemoveFromBasket(sku, 1);

        price = _sut.Checkout();

        price.Should().Be(0);
    }
}