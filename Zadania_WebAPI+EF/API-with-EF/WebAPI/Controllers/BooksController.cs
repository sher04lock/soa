using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI
{
    public class BooksController : ApiController
    {
        private readonly StoreContext db = new StoreContext();

        // GET api/<controller>
        public IEnumerable<Book> Get() => db.Books;

        // GET api/<controller>/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult Get(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [ResponseType(typeof(Book))]
        public IEnumerable<Book> Get([FromUri] string search)
        {
            return this.db.Books.Where(x => x.BookTitle.ToLower().Contains(search.ToLower()));
        }

        // POST api/<controller>
        [ResponseType(typeof(int))]
        public IHttpActionResult Post([FromBody]Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        [ResponseType(typeof(void))]
        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (id != book.Id)
                return BadRequest();

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                    return NotFound();
                else
                    throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/<controller>/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult Delete(int id)
        {
            Book book = this.db.Books.Find(id);
            if (book == null)
                return NotFound();

            this.db.Books.Remove(book);
            return Ok(book);
        }

        private bool BookExists(int id) => db.Books.Count(e => e.Id == id) > 0;
    }
}