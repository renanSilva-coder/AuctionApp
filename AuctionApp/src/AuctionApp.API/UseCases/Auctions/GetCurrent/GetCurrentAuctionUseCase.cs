using Microsoft.EntityFrameworkCore;
using AuctionApp.API.Contracts;
using AuctionApp.API.Entities;
using AuctionApp.API.Repositories;

namespace AuctionApp.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;

    public Auction? Execute() => _repository.GetCurrent();
}
