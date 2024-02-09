using Microsoft.AspNetCore.Mvc;
using AuctionApp.API.Communication.Requests;
using AuctionApp.API.Filters;
using AuctionApp.API.UseCases.Offers.CreateOffer;

namespace AuctionApp.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttibute))] 
public class OfferController : AuctionAppBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
