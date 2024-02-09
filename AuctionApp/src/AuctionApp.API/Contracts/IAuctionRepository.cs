using AuctionApp.API.Entities;

namespace AuctionApp.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
