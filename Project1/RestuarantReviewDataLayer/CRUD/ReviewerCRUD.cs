using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewDataLayer
{
    public class ReviewerCRUD
    {
        private RestaurantDBEntities1 _db;

        public ReviewerCRUD()
        {
            _db = new RestaurantDBEntities1();
        }
        public List<Reviewer> GetAllReviewers()
        {
             List<Reviewer> list = _db.Reviewers.ToList();
            return list;
        }

        public Reviewer GetReviewerById(int id)
        {
            var reviewer = _db.Reviewers.Find(id);
            return reviewer;
        }

        public void AddReviewer(Reviewer reviewer)
        {
            _db.Reviewers.Add(reviewer);
            _db.SaveChanges();
        }


    
    }
}
