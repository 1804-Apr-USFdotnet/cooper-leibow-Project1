using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewDataLayer;
using RestaurantLibrary.LibraryHelper;

namespace RestaurantLibrary.CRUD
{
    public class ReviewerCRUD
    {
        private RestaurantReviewDataLayer.ReviewerCRUD dalCrud;
        private ReviewerHelper reviewerHelper;


        public ReviewerCRUD()
        {
            dalCrud = new RestaurantReviewDataLayer.ReviewerCRUD();
            reviewerHelper = new ReviewerHelper();

        }

        public List<RestaurantLibrary.Models.Reviewer> GetAllReviewers()
        {

            List<RestaurantReviewDataLayer.Reviewer> dalReviewerList = dalCrud.GetAllReviewers();
            List<RestaurantLibrary.Models.Reviewer> bllReviewerList = new List<RestaurantLibrary.Models.Reviewer>();

            foreach (RestaurantReviewDataLayer.Reviewer dalReviewer in dalReviewerList)
            {
                bllReviewerList.Add(reviewerHelper.DataToLibrary(dalReviewer));
            }
            return bllReviewerList;

        }

        public RestaurantLibrary.Models.Reviewer GetReviewerById(int id)
        {
            RestaurantReviewDataLayer.Reviewer dllReviewer = dalCrud.GetReviewerById(id);
            RestaurantLibrary.Models.Reviewer bllReviewer = reviewerHelper.DataToLibrary(dllReviewer);
            return bllReviewer;
        }

        public void AddReview(RestaurantLibrary.Models.Reviewer reviewer)
        {
            RestaurantReviewDataLayer.Reviewer dalReviewer = reviewerHelper.LibraryToData(reviewer);
            dalCrud.AddReviewer(dalReviewer);
        }

        
    }
}
