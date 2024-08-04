namespace url_shortener.api.Models.Dto;

public class ShortLinkDto(string id, string shortLink)
{
    public string Id { get; } = id;
    public string ShortLink { get; } = shortLink;
}