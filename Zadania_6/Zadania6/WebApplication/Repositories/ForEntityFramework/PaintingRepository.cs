using DAL;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace WebApplication.Repositories.FroEntityFramework
{
    public class PaintingRepository : IPaintingRepository
    {
        private readonly MuseumContext db = new MuseumContext();

        public Painting Get(int id) => db.Paintings.Find(id);

        public List<Painting> GetAll() => db.Paintings.ToList();

        public int Add(Painting value)
        {
            var painting = db.Paintings.Add(value);
            db.SaveChanges();
            return painting.Id;
        }

        public bool Delete(int id)
        {
            var painting = db.Paintings.Find(id);
            if (painting == null)
                return false;
            db.Paintings.Remove(painting);
            return true;
        }

        public bool Update(Painting value)
        {
            db.Entry(value).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}