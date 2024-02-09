using Bogus;
using FluentAssertions;
using Moq;
using AuctionApp.API.Communication.Requests;
using AuctionApp.API.Contracts;
using AuctionApp.API.Entities;
using AuctionApp.API.Services;
using AuctionApp.API.UseCases.Auctions.GetCurrent;
using AuctionApp.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        // Arrange

        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        // Act
        var act = () => useCase.Execute(itemId, request);

        // Assert
        act.Should().NotThrow();
    }
}