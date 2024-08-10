namespace url_shortener.api.Services;

using Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Models.Dto;
using Microsoft.AspNetCore.Mvc;

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

    public async Task<ShortLinkDto> GetAsync(string id){

        var filter = Builders<ShortLinkDto>.Filter.Eq(s => s.Id, id);

        var result = await _collection.Find(filter).FirstOrDefaultAsync();
        return result;
    }

    public async Task<string?> GetFullLinkAsync(string short_link){

        var filter = Builders<ShortLinkDto>.Filter.Eq(s => s.ShortLink, short_link);

        var result = await _collection.Find(filter).FirstOrDefaultAsync();

        if(result == null){
            Console.WriteLine("In GetFullLinkAsync: result is null for shortlink " + short_link);
            return null;
        }

        return result.FullLink;
    }

    public async Task<List<ShortLinkDto>> GetAsync()
    {
        var filter = Builders<ShortLinkDto>.Filter.Empty;
        
        var result = await _collection.Find(filter).ToListAsync();
    
        return result;
    }
}