using Interfaces;
using LiteDB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAndPersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _peopleConnection = @"database.db";

        public int Add(Person person)
        {
            using (var db = new LiteDatabase(this._peopleConnection))
            {
                var repository = db.GetCollection<Person>("people");
                if (repository.FindById(person.Id) != null)
                    repository.Update(person);
                else
                    repository.Insert(person);

                return person.Id;
            }
        }

        public bool Delete(int id)
        {
            {
                using (var db = new LiteDatabase(this._peopleConnection))
                {
                    var repository = db.GetCollection<Person>("people");
                    return repository.Delete(id);
                }
            }
        }

        public Person Get(int id)
        {
            using (var db = new LiteDatabase(this._peopleConnection))
            {
                var repository = db.GetCollection<Person>("people");
                return repository.FindById(id);
            }
        }

        public List<Person> GetAll()
        {
            using (var db = new LiteDatabase(this._peopleConnection))
            {
                var repository = db.GetCollection<Person>("people");
                return repository.FindAll().ToList();
            }
        }


        public Person Update(Person person)
        {
            using (var db = new LiteDatabase(this._peopleConnection))
            {

                var repository = db.GetCollection<Person>("people");
                if (repository.Update(person))
                    return person;
                else
                    return null;
            }
        }
    }
}
