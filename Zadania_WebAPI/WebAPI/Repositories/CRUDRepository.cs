using LiteDB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class CRUDRepository<T> : ICRUDRepository<T> where T : class, IDBObject
    {
        protected readonly string database;
        protected readonly string collection;

        public CRUDRepository(string database, string collection)
        {
            this.database = database;
            this.collection = collection;
        }

        public int Add(T book)
        {
            {
                using (var db = new LiteDatabase(this.database))
                {
                    var repository = db.GetCollection<T>(this.collection);
                    if (repository.FindById(book.Id) != null)
                        repository.Update(book);
                    else
                        repository.Insert(book);

                    return book.Id;
                }
            }
        }

        public bool Delete(int id)
        {
            {
                using (var db = new LiteDatabase(this.database))
                {
                    var repository = db.GetCollection<T>(this.collection);
                    return repository.Delete(id);
                }
            }
        }

        public T Get(int id)
        {
            using (var db = new LiteDatabase(this.database))
            {
                var repository = db.GetCollection<T>(this.collection);
                return repository.FindById(id);
            }
        }

        public List<T> GetAll()
        {
            using (var db = new LiteDatabase(this.database))
            {
                var repository = db.GetCollection<T>(this.collection);
                return repository.FindAll().ToList();
            }
        }

        public T Update(T book)
        {
            using (var db = new LiteDatabase(this.database))
            {

                var repository = db.GetCollection<T>(this.collection);
                if (repository.Update(book))
                    return book;
                else
                    return null;
            }
        }
    }
}
