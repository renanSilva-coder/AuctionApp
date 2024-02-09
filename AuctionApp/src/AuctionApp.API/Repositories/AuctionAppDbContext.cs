using Microsoft.EntityFrameworkCore;
using AuctionApp.API.Entities;

namespace AuctionApp.API.Repositories;

public class AuctionAppDbContext : DbContext
{
    public AuctionAppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
 