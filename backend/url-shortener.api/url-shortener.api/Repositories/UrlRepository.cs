using MongoDB.Driver;
using url_shortener.api.Models.Dto;

namespace url_shortener.api.Repositories;

public class UrlRepository(MongoClient mongoClient) : IUrlRepository
{
    public async Task SaveAsync(UrlDto url)
    {
        var database = mongoClient.GetDatabase("urlshortener");
        var collection = database.GetCollection<UrlDto>("urlmappings");
        await collection.InsertOneAsync(url);
    }
}