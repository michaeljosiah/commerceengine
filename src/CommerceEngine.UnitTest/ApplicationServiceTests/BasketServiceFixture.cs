using System;
using CommerceEngine.Application.Exceptions;
using CommerceEngine.Application.Services;
using CommerceEngine.Core.Interfaces;
using CommerceEngine.Infrastructure.Data;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Xunit;

namespace CommerceEngine.UnitTest.ApplicationServiceTests
{
    public class BasketServiceFixture
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IDiscountRepository _discountRepository;
        public BasketServiceFixture()
        {
            _basketRepository = new MockBasketRepository();
            _discountRepository = new MockDiscountRepository();
        }
        [Fact]
        public void WhenCreateBasketMethodIsCalled_ThenAValidBasketDtoIsReturned()
        {
            //Arrange
            var basketService = new BasketService(_basketRepository,_discountRepository);

            //Act
            var basket = basketService.CreateBasket();

            //Assert
            basket.Should().NotBe(null);
            basket.Items.Count.Should().Be(0);
            basket.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void GivenAnInvalidBasketId_WhenAddItemToBasketIsCalled_ThenBasketItemNotFoundExceptionIsThrown()
        {
            //Arrange
            var basketService = new BasketService(_basketRepository, _discountRepository);

            //Act
            Action act = () =>
            {
                basketService.AddItemToBasket(Guid.NewGuid(), Guid.NewGuid(), 1, 1);
            };

            //Assert
            act.Should().Throw<BasketNotFoundException>();

        }

    }
}
