using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReviewAndPersonWCFService" in both code and config file together.
    [ServiceContract]
    public interface IReviewAndPersonWCFService
    {
        [OperationContract]
        List<Person> GetAllPeople();

        [OperationContract]
        int AddPerson(Person person);

        [OperationContract]
        Person GetPerson(int id);

        [OperationContract]
        Person UpdatePerson(Person person);


        [OperationContract]
        List<Review> GetAllReviews();

        [OperationContract]
        int AddReview(Review review);

        [OperationContract]
        Review GetReview(int id);

        [OperationContract]
        Review UpdateReview(Review review);
    }
}
