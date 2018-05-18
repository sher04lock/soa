using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        int Add(Review review);
        Review Get(int id);
        Review Update(Review review);
        bool Delete(int id);
    }
}
