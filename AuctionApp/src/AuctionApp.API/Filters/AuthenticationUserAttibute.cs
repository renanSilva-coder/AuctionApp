using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AuctionApp.API.Contracts;

namespace AuctionApp.API.Filters;

public class AuthenticationUserAttibute : AuthorizeAttribute, IAuthorizationFilter
{
    private IUserRepository _repository;
    private readonly IFromBase64Converter _fromBase64Converter;

    public AuthenticationUserAttibute(IUserRepository repository, IFromBase64Converter fromBase64Converter)
    {
        _repository = repository;
        _fromBase64Converter = fromBase64Converter;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = _fromBase64Converter.FromBase64String(token);

            var exist = _repository.ExistUserWithEmail(email);

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("E-mail not valid!");
            }
        } catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
        
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is missing.");
        }

        return authentication["Bearer ".Length..];
    }
}