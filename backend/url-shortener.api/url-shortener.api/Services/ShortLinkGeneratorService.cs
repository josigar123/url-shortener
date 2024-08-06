using url_shortener.api.Interfaces;

namespace url_shortener.api.Services;

public class ShortLinkGeneratorService : IShortLinkGenerator
{
    private const string BaseUrl = "j.ly/";
    private const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
    
    public string GenerateShortLink()
    {
        return BaseUrl + GenerateUniqueIdentifier();
    }

    private string GenerateUniqueIdentifier()
    {
        var random = new Random();
        
        var uniqueId = new string(
            Enumerable.Range(0, 6)
                .Select(_ => Base64Chars[random.Next(Base64Chars.Length)])
                .ToArray()
        );

        return uniqueId;
    }
}