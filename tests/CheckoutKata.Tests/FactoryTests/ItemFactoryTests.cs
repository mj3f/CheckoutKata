using CheckoutKata.Console.Factories;
using CheckoutKata.Console.Models;
using FluentAssertions;

namespace CheckoutKata.Tests.FactoryTests;

public class ItemFactoryTests
{
    private readonly ItemFactory _sut = new();

    [Fact]
    public void CreateItemA_ShouldCreateItemWithSkuOfAAndPriceOf10()
    {
        IItem item = _sut.CreateItemA();

        item.Sku.Should().Be("A");
        item.Price.Should().Be(10);
    }
    
    [Fact]
    public void CreateItemB_ShouldCreateItemWithSkuOfBAndPriceOf15()
    {
        IItem item = _sut.CreateItemB();

        item.Sku.Should().Be("B");
        item.Price.Should().Be(15);
    }
    
    [Fact]
    public void CreateItemC_ShouldCreateItemWithSkuOfCAndPriceOf40()
    {
        IItem item = _sut.CreateItemC();

        item.Sku.Should().Be("C");
        item.Price.Should().Be(40);
    }
    
    [Fact]
    public void CreateItemD_ShouldCreateItemWithSkuOfDAndPriceOf55()
    {
        IItem item = _sut.CreateItemD();

        item.Sku.Should().Be("D");
        item.Price.Should().Be(55);
    }
    
}