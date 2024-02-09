using AuctionApp.API.Contracts;
namespace AuctionApp.API.Utils.Converters;

public class FromBase64Converter : IFromBase64Converter
{
    public string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
