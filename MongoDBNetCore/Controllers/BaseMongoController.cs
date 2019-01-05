using Microsoft.AspNetCore.Mvc;
using MongoDBNetCore.Model;
using MongoDBNetCore.Services.MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBNetCore.Controllers
{
    public class BaseMongoController<TModel> : ControllerBase
        where TModel : MongoBaseModel
    {
        public BaseMongoRepository<TModel> BaseMongoRepository { get; set; }

        public BaseMongoController(BaseMongoRepository<TModel> baseMongoRepository)
        {
            this.BaseMongoRepository = baseMongoRepository;
        }

        [HttpGet("{id}")]
        public ActionResult GetModel(string id)
        {
            return Ok(this.BaseMongoRepository.GetById(id));
        }

        [HttpGet]
        public ActionResult GetModelList()
        {
            return Ok(this.BaseMongoRepository.GetList());
        }

        [HttpPost]
        public ActionResult AddModel(TModel model)
        {
            return Ok(this.BaseMongoRepository.Create(model));
        }

        [HttpPut]
        public ActionResult UpdateModel(string id,TModel model)
        {
            this.BaseMongoRepository.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteModel(string id)
        {
            this.BaseMongoRepository.Delete(id);
        }

    }
}
