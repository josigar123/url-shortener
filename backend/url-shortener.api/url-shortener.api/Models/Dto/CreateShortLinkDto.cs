namespace url_shortener.api.Models.Dto;

public class CreateShortLinkDto(string shortLink)
{
    public string ShortLink { get; } = shortLink;
}