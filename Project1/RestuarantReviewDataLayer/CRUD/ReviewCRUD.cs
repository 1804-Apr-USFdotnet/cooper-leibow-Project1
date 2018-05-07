using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewDataLayer.CRUD
{
    public class ReviewCRUD
    {
        private RestaurantDBEntities1 _db;

        public ReviewCRUD()
        {
            _db = new RestaurantDBEntities1();
        }
        public ICollection<Review> GetAllReviews(int id)
        {
            var rest = _db.Restaurants.Find(id);
            ICollection<Review> list = rest.Reviews;
            return list;
        }

        public Review GetReviewById(int id)
        {
            var res = _db.Reviews.Find(id);
            return res;
        }

        public void AddReview(Review rev)
        {
            _db.Reviews.Add(rev);
            _db.SaveChanges();
        }

        public void UpdateReviewById(Review rev2)
        {
            
            Review rev1 = _db.Reviews.Find(rev2.ID);
            
            rev1.rating = rev2.rating;
            rev1.content = rev2.content;
            _db.SaveChanges();

        }

        public void DeleteRestaurantById(int id)
        {

            Review rev = _db.Reviews.Find(id);
            _db.Reviews.Remove(rev);
            _db.SaveChanges();
        }
    }
}
