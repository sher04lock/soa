using Interfaces;
using LiteDB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRepository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _moviesConnection = @"movies.db";

        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<Movie>("movies");
                if (repository.FindById(movie.Id) != null)
                    repository.Update(movie);
                else
                    repository.Insert(movie);

                return movie.Id;
            }
        }

        public bool Delete(int id)
        {
            {
                using (var db = new LiteDatabase(this._moviesConnection))
                {
                    var repository = db.GetCollection<Movie>("movies");
                    return repository.Delete(id);
                }
            }
        }

        public Movie Get(int id)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<Movie>("movies");
                return repository.FindById(id);
            }
        }

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<Movie>("movies");
                return repository.FindAll().ToList();
            }
        }


        public Movie Update(Movie movie)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {

                var repository = db.GetCollection<Movie>("movies");
                if (repository.Update(movie))
                    return movie;
                else
                    return null;
            }
        }
    }
}
