namespace url_shortener.api.Services;

using Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Models.Dto;

public class MongoDbService
{
    private readonly IMongoCollection<ShortLinkDto> _collection;
    public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
        var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _collection = database.GetCollection<ShortLinkDto>(mongoDbSettings.Value.CollectionName);
    }

    public async Task SaveAsync(ShortLinkDto shortLinkDto)
    {
        await _collection.InsertOneAsync(shortLinkDto);
    }

    public async Task<List<ShortLinkDto>> GetAsync()
    {
        var filter = Builders<ShortLinkDto>.Filter.Empty;
        
        var result = await _collection.Find(filter).ToListAsync();
    
        return result;
    }
}