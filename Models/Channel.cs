using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace myapi.Models;

public class ChannelDebugResponse
{
    public List<Channel> channels { get; set; }
}

public class Channel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string Id { get; set; }

    [BsonElement("key")]
    public string Key { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("weight")]
    public decimal Weight { get; set; }
}

public class ChannelResponse
{
    public List<ChannelWithoutId> Channels { get; set; }
}

[BsonIgnoreExtraElements]
public class ChannelWithoutId
{
    [BsonElement("key")]
    public string Key { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("weight")]
    public decimal Weight { get; set; }
}
