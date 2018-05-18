using Client2.ServiceReference1;
using Client2.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    class Program
    {
        static MoviesWCFServiceClient _moviesService = new MoviesWCFServiceClient();
        static ReviewAndPersonWCFServiceClient _reviewPersonService = new ReviewAndPersonWCFServiceClient();
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            
            var movies = _moviesService.GetAllMovies();
            if (movies.Count() < 3)
            {
                _moviesService.AddMovie(new Movie
                {
                    Title = "Bad Boys 2",
                    ReleaseYear = 1992
                });
                _moviesService.AddMovie(new Movie
                {
                    Title = "Bad Boys",
                    ReleaseYear = 1990
                });
                _moviesService.AddMovie(new Movie
                {
                    Title = "Losing hope",
                    ReleaseYear = 2018
                });
            }            

            Console.WriteLine(_moviesService.GetAllMovies().Count());
            Console.WriteLine(_moviesService.GetAllMovies().Select(m => $"{m.Id} | {m.Title} ({m.ReleaseYear})").Aggregate((a,b) => a + "\n" + b));
            Console.ReadKey();
        }
    }
}
