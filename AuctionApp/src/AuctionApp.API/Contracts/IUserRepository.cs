using AuctionApp.API.Entities;

namespace AuctionApp.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
