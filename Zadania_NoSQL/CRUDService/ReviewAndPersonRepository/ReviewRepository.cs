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
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _reviewsConnection = @"database.db";

        public List<Review> GetAll()
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var repository = db.GetCollection<Review>("reviews");
                return repository.FindAll().ToList();
            }
        }

        public int Add(Review review)
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var repository = db.GetCollection<Review>("reviews");
                repository.Insert(review);
                return review.Id;
            }
        }

        public Review Get(int id)
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var repository = db.GetCollection<Review>("reviews");
                return repository.FindById(id);
            }
        }

        public Review Update(Review review)
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {

                var repository = db.GetCollection<Review>("reviews");
                if (repository.Update(review))
                    return review;
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var repository = db.GetCollection<Review>("reviews");
                return repository.Delete(id);
            }
        }
    }
}
