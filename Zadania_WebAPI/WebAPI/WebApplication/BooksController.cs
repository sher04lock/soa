using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication
{
    public class BooksController : ApiController
    {
        private readonly ICRUDRepository<Book> repository = new BookRepository();


        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            return this.repository.GetAll();
        }

        // GET api/<controller>/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult Get(int id)
        {
            Book book = this.repository.Get(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [ResponseType(typeof(Book))]
        public IEnumerable<Book> Get([FromUri] string search)
        {
            return this.repository.GetAll().Where(x => x.BookTitle.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        // POST api/<controller>
        [ResponseType(typeof(int))]
        public IHttpActionResult Post([FromBody]Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.repository.Add(book));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Book book)
        {
            var dbBook = this.repository.Get(id);
            dbBook.BookTitle = book.BookTitle;
            dbBook.ISBN = book.ISBN;
            this.repository.Update(dbBook);
        }

        // DELETE api/<controller>/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult Delete(int id)
        {
            Book book = this.repository.Get(id);
            if (book == null)
                return NotFound();

            this.repository.Delete(book.Id);
            return Ok(book);
        }
    }
}