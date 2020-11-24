using System;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace CommerceEngine.UnitTest.DomainTests
{
    public class BasketFixture
    {
        [Fact]
        public void WhenAnItemIsAdded_ThenBasketItemCountIncreases()
        {
            //Arrange
            var basket = new Basket();

            //Act
            basket.AddItem(Guid.NewGuid(),1,1);

            //Assert
            basket.Items.Count.Should().Be(1);
        }

        [Fact]
        public void GivenAnInvalidBasketItemId_WhenDeleteBasketItemIsCalled_ThenBasketItemNotFoundExceptionIsThrown()
        {
            //Arrange
            var basket = new Basket();
            basket.AddItem(Guid.NewGuid(),1,1);

            //Act
            Action act = () =>
            {
                basket.DeleteBasketItem(Guid.NewGuid());
            };

            //Assert
            act.Should().Throw<BasketItemNotFoundException>();

        }


    }
}
