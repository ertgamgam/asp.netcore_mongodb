using Microsoft.AspNetCore.Mvc;
using MongoDBNetCore.Model;
using MongoDBNetCore.Services.MongoRepository;

namespace MongoDBNetCore.Controllers
{
    public abstract class BaseMongoController<TModel> : ControllerBase
        where TModel : MongoBaseModel
    {
        public BaseMongoRepository<TModel> BaseMongoRepository { get; set; }

        public BaseMongoController(BaseMongoRepository<TModel> baseMongoRepository)
        {
            this.BaseMongoRepository = baseMongoRepository;
        }

        [HttpGet("{id}")]
        public virtual ActionResult GetModel(string id)
        {
            return Ok(this.BaseMongoRepository.GetById(id));
        }

        [HttpGet]
        public virtual ActionResult GetModelList()
        {
            return Ok(this.BaseMongoRepository.GetList());
        }

        [HttpPost]
        public virtual ActionResult AddModel(TModel model)
        {
            return Ok(this.BaseMongoRepository.Create(model));
        }

        [HttpPut]
        public virtual ActionResult UpdateModel(string id,TModel model)
        {
            this.BaseMongoRepository.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual void DeleteModel(string id)
        {
            this.BaseMongoRepository.Delete(id);
        }

    }
}
