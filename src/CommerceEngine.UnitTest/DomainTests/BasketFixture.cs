using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Entities;
using FluentAssertions;
using Xunit;

namespace CommerceEngine.UnitTest.DomainTests
{
    public class BasketFixture
    {
        [Fact]
        public void WhenAnItemIsAddedThenBasketItemCountIncreases()
        {
            //Arrange
            var basket = new Basket();

            //Act
            basket.AddItem(Guid.NewGuid(),1,1);

            //Assert
            basket.Items.Count.Should().Be(1);
        }


    }
}
