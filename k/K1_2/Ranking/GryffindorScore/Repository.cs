using LiteDB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GryffindorScore
{
    public class CRUDRepository
    {
        protected readonly string database;
        protected readonly string collection;

        public CRUDRepository(string database, string collection)
        {
            this.database = database;
            this.collection = collection;
        }

        public void Add(Position pos)
        {
            {
                using (var db = new LiteDatabase(this.database))
                {
                    var repository = db.GetCollection<Position>(this.collection);
                    var position = repository.FindOne(p => p.Name.ToLower() == pos.Name.ToLower());
                    if (position != null)
                    {
                        repository.Update(pos);
                    }
                    else
                        repository.Insert(pos);
                }
            }
        }

        public void Delete(Position pos)
        {
            {
                using (var db = new LiteDatabase(this.database))
                {
                    var repository = db.GetCollection<Position>(this.collection);
                    repository.Delete(p => p.Name.ToLower() == pos.Name.ToLower());
                }
            }
        }

        public Position Get(Position pos)
        {
            using (var db = new LiteDatabase(this.database))
            {
                var repository = db.GetCollection<Position>(this.collection);
                return repository.FindOne(p => p.Name.ToLower() == pos.Name.ToLower());
            }
        }

        public List<Position> GetAll()
        {
            using (var db = new LiteDatabase(this.database))
            {
                var repository = db.GetCollection<Position>(this.collection);
                return repository.FindAll().ToList();
            }
        }

        public bool Update(Position value)
        {
            using (var db = new LiteDatabase(this.database))
            {
                var repository = db.GetCollection<Position>(this.collection);
                return repository.Update(value);
            }
        }
    }
}