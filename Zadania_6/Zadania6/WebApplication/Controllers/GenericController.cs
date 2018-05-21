using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class GenericController<T> : ApiController where T : class
    {
        private readonly IRepository<T> db;
        private readonly ILogger logger;

        public GenericController(IRepository<T> repo, ILogger logger)
        {
            db = repo;
            this.logger = logger;
        }

        // GET api/<controller>
        public IEnumerable<T> Get()
        {
            logger.Write("[GET] (Artists)", LogLevel.INFO);
            return db.GetAll();
        }

        // GET api/<controller>/5
        public T Get(int id)
        {
            logger.Write($"[GET] (Artists) /{id}", LogLevel.INFO);
            return db.Get(id);
        }

        // POST api/<controller>
        public int Post([FromBody]T value)
        {
            logger.Write("[POST] (Artists)", LogLevel.INFO);
            return db.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]T value)
        {
            logger.Write($"[PUT] (Artists) /{id}", LogLevel.INFO);
            db.Update(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            logger.Write($"[DELETE] (Artists) /{id}", LogLevel.INFO);
            db.Delete(id);
        }
    }
}
