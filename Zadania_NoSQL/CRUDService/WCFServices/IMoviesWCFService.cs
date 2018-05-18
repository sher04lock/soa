using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMoviesWCFService" in both code and config file together.
    [ServiceContract]
    public interface IMoviesWCFService
    {
        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        int AddMovie(Movie movie);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        Movie UpdateMovie(Movie movie);        
    }
}
