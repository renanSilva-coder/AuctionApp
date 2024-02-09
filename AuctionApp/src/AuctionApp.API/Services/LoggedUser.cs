using AuctionApp.API.Contracts;
using AuctionApp.API.Entities;
namespace AuctionApp.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;
    private readonly IFromBase64Converter _fromBase64Converter;

    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository, IFromBase64Converter fromBase64Converter)
    {
        _httpContextAccessor = httpContext;
        _repository = repository;
        _fromBase64Converter = fromBase64Converter;
    }
     
    public User User()
    {
        var token = TokenOnRequest();
        var email = _fromBase64Converter.FromBase64String(token);

        return _repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..];
    }
}
