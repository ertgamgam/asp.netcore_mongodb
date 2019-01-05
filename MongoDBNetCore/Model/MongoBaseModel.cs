using MongoDB.Bson;

namespace MongoDBNetCore.Model
{
    public abstract class MongoBaseModel
    {
        public ObjectId Id { get; set; }
    }
}
