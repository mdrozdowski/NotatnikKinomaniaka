using DatabaseLayer.Context;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class ReviewRepository
    {
        DatabaseContext db = new DatabaseContext();

        public void Add(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }

        public Review GetReview(int? id)
        {
           return db.Reviews.Find(id);
        }
    }
}
