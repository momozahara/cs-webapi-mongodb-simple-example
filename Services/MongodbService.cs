using myapi.Models;
using myapi.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace myapi.Services;

public class ChannelService
{
    private readonly IMongoCollection<Channel> _channelCollection;
    private readonly IMongoCollection<ChannelWithoutId> _channelWithoutIdCollection;

    public ChannelService(IOptions<ChannelDatabaseSettings> channelDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            channelDatabaseSettings.Value.ConnectionString
            );

        var mongoDatabase = mongoClient.GetDatabase(
            channelDatabaseSettings.Value.DatabaseName
            );

        _channelCollection = mongoDatabase.GetCollection<Channel>(
            channelDatabaseSettings.Value.ChannelCollectionName
            );

        _channelWithoutIdCollection = mongoDatabase.GetCollection<ChannelWithoutId>(
            channelDatabaseSettings.Value.ChannelCollectionName
            );
    }

    public async Task<List<Channel>> GetAsync()
    {
        return await _channelCollection.Find(_ => true).ToListAsync();
    }

    public async Task<List<ChannelWithoutId>> GetWithoutIdAsync()
    {
        return await _channelWithoutIdCollection.Find(_ => true).ToListAsync();
    }
}
