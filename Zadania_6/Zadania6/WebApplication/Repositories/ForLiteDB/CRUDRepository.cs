using LiteDB;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Repositories.ForLiteDB
{
    public abstract class CRUDRepository<T> : IRepository<T> where T : class, IDBObject
    {
        protected readonly string database;
        protected readonly string collection;

        public CRUDRepository(string database, string collection)
        {
            this.database = database;
            this.collection = collection;
        }

        public int Add(T value)
        {
            {
                using (var db = new LiteDatabase(this.database))
                {
                    var repository = db.GetCollection<T>(this.collection);
                    if (repository.FindById(value.Id) != null)
                        repository.Update(value);
                    else
                        repository.Insert(value);

                    return value.Id;
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

        public bool Update(T value)
        {
            using (var db = new LiteDatabase(this.database))
            {
                var repository = db.GetCollection<T>(this.collection);
                return repository.Update(value);
            }
        }
    }
}