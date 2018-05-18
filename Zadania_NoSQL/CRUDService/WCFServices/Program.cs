using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            
            ServiceHost movieService = new ServiceHost(typeof(MoviesWCFService));
            movieService.Open();

            Console.WriteLine("Movie Service is working!");

            ServiceHost reviewAndPersonService = new ServiceHost(typeof(ReviewAndPersonWCFService));
            reviewAndPersonService.Open();

            Console.WriteLine("Review & Persons services are working!");
            Console.ReadLine();

            movieService.Close();
            reviewAndPersonService.Close();
            //var repo = new MoviesWCFService();
            //Console.WriteLine(repo.GetAllMovies().Count);
            //Console.ReadKey();
        }
    }
}
