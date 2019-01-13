﻿using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBNetCore.Model;

namespace MongoDBNetCore.Services.MongoRepository
{
    public abstract class BaseMongoRepository<TModel>
        where TModel : MongoBaseModel
    {
        private readonly IMongoCollection<TModel> mongoCollection;

        public BaseMongoRepository(string mongoDBConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<TModel>(collectionName);
        }

        public virtual List<TModel> GetList()
        {
            return mongoCollection.Find(book => true).ToList();
        }

        public virtual TModel GetById(string id)
        {
            var docId = new ObjectId(id);
            return mongoCollection.Find<TModel>(m => m.Id == docId).FirstOrDefault();
        }

        public virtual TModel Create(TModel model)
        {
            mongoCollection.InsertOne(model);
            return model;
        }

        public virtual void Update(string id, TModel model)
        {
            var docId = new ObjectId(id);
            mongoCollection.ReplaceOne(m => m.Id == docId, model);
        }

        public virtual void Delete(TModel model)
        {
            mongoCollection.DeleteOne(m => m.Id == model.Id);
        }

        public virtual void Delete(string id)
        {
            var docId = new ObjectId(id);
            mongoCollection.DeleteOne(m => m.Id == docId);
        }
    }
}
