using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace url_shortener.api.Models.Dto;

public class ShortLinkDto(string fullLink, string shortLink)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("short_link")]
    [JsonPropertyName("short_link")]
    public string? ShortLink { get; set; } = shortLink;

    [BsonElement("full_link")]
    [JsonPropertyName("full_link")]
    public string FullLink { get; set; } = fullLink;
}