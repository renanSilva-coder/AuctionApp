using Microsoft.AspNetCore.Mvc;
using AuctionApp.API.Entities;
using AuctionApp.API.UseCases.Auctions.GetCurrent;

namespace AuctionApp.API.Controllers;

public class AuctionController : AuctionAppBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {

        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }
}
