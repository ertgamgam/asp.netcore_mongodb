using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBNetCore.Model
{
    public class RockSongs:MongoBaseModel
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Singer")]
        public string Singer { get; set; }
    }
}
