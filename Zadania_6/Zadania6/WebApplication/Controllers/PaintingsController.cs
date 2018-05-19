using DAL;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class PaintingsController : ApiController
    {
        private readonly IPaintingRepository db;
        private readonly ILogger logger;

        public PaintingsController(IPaintingRepository repository, ILogger logger)
        {
            db = repository;
            this.logger = logger;
        }

        public IEnumerable<Painting> Get()
        {
            logger.Write($"[GET ALL] (Paintings)", LogLevel.INFO);
            return db.GetAll();
        }

        [ResponseType(typeof(Painting))]
        public IHttpActionResult Get(int id)
        {
            logger.Write($"[GET] (Paintings) /{id}", LogLevel.INFO);

            var book = db.Get(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [ResponseType(typeof(int))]
        public IHttpActionResult Post([FromBody]Painting painting)
        {
            logger.Write($"[POST] (Paintings)", LogLevel.INFO);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = db.Add(painting);
            return Ok(id);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]Painting painting)
        {
            logger.Write($"[PUT] (Paintings) /{id}", LogLevel.INFO);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != painting.Id)
                return BadRequest();

            if (!PaintingExists(id))
                return NotFound();

            if (db.Update(painting))
                return Ok();

            return InternalServerError();
        }

        [ResponseType(typeof(Painting))]
        public IHttpActionResult Delete(int id)
        {
            logger.Write($"[DELETE] (Paintings) /{id}", LogLevel.INFO);
            Painting painting = db.Get(id);
            if (painting == null)
                return NotFound();

            db.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool PaintingExists(int id) => db.GetAll().Count(e => e.Id == id) > 0;
    }
}