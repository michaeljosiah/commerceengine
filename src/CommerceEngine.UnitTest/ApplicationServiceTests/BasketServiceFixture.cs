using System;
using System.Collections.Generic;
using CommerceEngine.Application.Exceptions;
using CommerceEngine.Application.Services;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;
using CommerceEngine.Infrastructure.Data;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
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
        public void GivenABasketContainingAPromotionItem_WhenDiscountIsAppliedToBasket_AValidDiscountIsApplied()
        {
            //Arrange
            var mockRepo = new Mock<IDiscountRepository>();
            var productId = Guid.Parse("976AC9EF-6958-41B3-9C21-04EF6E169D0B");
            var testDiscount = new List<Discount>
            {
                new Discount
                {
                    Id = Guid.Parse("E1D078F9-322B-42A4-BA1B-8C761DF4ADA2"),
                    DiscountAmount = 80,
                    DiscountType = Core.Enums.DiscountType.AssignedToProduct,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.Now.AddDays(7),
                    IsPercentage = true,
                    Name = "Milk 80% off",
                    ProductId = productId
                }
            };
            mockRepo.Setup(x => x.GetAvailabileDiscounts(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(testDiscount);

            var basketService = new BasketService(_basketRepository, mockRepo.Object);
            var basket = basketService.CreateBasket();
            basket = basketService.AddItemToBasket(basket.Id, productId, 1.30m, 1);


            //Act
            basket = basketService.ApplyDiscounts(basket.Id);

            //Assert
            basket.Items.Count.Should().Be(1);
            basket.DiscountAmount.Should().Be(1.04m);
            basket.DiscountText.Should().Be("Milk 80% off");
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
