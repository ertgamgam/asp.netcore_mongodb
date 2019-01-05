using Microsoft.AspNetCore.Mvc;
using MongoDBNetCore.Model;
using MongoDBNetCore.Services.MongoRepository;

namespace MongoDBNetCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RockSongsController : BaseMongoController<RockSongs>
    {
       
        public RockSongsController(RockSongsRepository rockSongsRepository) : base(rockSongsRepository)
        {
        }
    }
}
