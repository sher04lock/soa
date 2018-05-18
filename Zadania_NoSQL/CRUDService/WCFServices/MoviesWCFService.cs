using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Interfaces;
using Models;
using MovieRepository;

namespace WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MoviesWCFService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MoviesWCFService : IMoviesWCFService
    {

        private readonly IMovieRepository _movieRepository;
        
        public MoviesWCFService()
        {
            this._movieRepository = new MovieRepository.MovieRepository();

        }
        public int AddMovie(Movie movie)
        {
            return this._movieRepository.Add(movie);
        }        

        public List<Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll();
        }

        public Movie GetMovie(int id)
        {
            return this._movieRepository.Get(id);
        }

        public Movie UpdateMovie(Movie movie)
        {
            return this._movieRepository.Update(movie);
        }
    }
}
