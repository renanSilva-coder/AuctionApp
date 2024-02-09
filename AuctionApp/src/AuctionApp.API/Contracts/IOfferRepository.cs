using AuctionApp.API.Entities;

namespace AuctionApp.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
