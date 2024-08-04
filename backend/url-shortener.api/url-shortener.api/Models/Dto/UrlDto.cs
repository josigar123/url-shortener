namespace url_shortener.api.Models.Dto;

public class UrlDto(string url)
{
    public string Url { get; } = url;
}