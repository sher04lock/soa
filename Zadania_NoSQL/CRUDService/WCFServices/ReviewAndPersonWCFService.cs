using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Interfaces;
using Models;
using ReviewAndPersonRepository;

namespace WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReviewAndPersonWCFService" in both code and config file together.
    public class ReviewAndPersonWCFService : IReviewAndPersonWCFService
    {

        private readonly IPersonRepository _personRepository;
        private readonly IReviewRepository _reviewRepository;

        public ReviewAndPersonWCFService()
        {
            _personRepository = new PersonRepository();
            _reviewRepository = new ReviewRepository();

        }

        public int AddPerson(Person person)
        {
            return this._personRepository.Add(person);
        }

        public int AddReview(Review review)
        {
            return this._reviewRepository.Add(review);
        }

        public List<Person> GetAllPeople()
        {
            return this._personRepository.GetAll();
        }

        public List<Review> GetAllReviews()
        {
            return this._reviewRepository.GetAll();
        }

        public Person GetPerson(int id)
        {
            return this._personRepository.Get(id);
        }

        public Review GetReview(int id)
        {
            return this._reviewRepository.Get(id);
        }

        public Person UpdatePerson(Person person)
        {
            return this._personRepository.Update(person);
        }

        public Review UpdateReview(Review review)
        {
            return this._reviewRepository.Update(review);
        }
    }
}
