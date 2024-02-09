using AuctionApp.API.Repositories;
using Microsoft.EntityFrameworkCore;
using AuctionApp.API.Contracts;
using AuctionApp.API.Entities;

namespace AuctionApp.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
   private readonly AuctionAppDbContext _dbContext;
   public AuctionRepository(AuctionAppDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext
           .Auctions
           .Include(auction => auction.Items)
           .FirstOrDefault(auction => today >= auction.Starts);
    }
}
