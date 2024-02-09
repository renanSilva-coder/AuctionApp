using AuctionApp.API.Contracts;
using AuctionApp.API.Entities;

namespace AuctionApp.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly AuctionAppDbContext _dbContext;
    public UserRepository(AuctionAppDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}
