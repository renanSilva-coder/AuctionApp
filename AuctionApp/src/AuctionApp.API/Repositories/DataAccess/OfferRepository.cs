using AuctionApp.API.Contracts;
using AuctionApp.API.Entities;

namespace AuctionApp.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly AuctionAppDbContext _dbContext;
    public OfferRepository(AuctionAppDbContext dbContext) => _dbContext = dbContext;
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();

    }
}
