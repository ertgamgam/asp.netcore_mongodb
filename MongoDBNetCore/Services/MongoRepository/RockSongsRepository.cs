using MongoDBNetCore.Model;

namespace MongoDBNetCore.Services.MongoRepository
{
    public class RockSongsRepository : BaseMongoRepository<RockSongs>
    {
        public RockSongsRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)            
        {            
        }
    }
}
