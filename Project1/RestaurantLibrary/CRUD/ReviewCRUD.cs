using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.LibraryHelper;

namespace RestaurantLibrary.CRUD
{
    public class ReviewCRUD
    {
        private RestaurantReviewDataLayer.CRUD.ReviewCRUD  dalCrud;
        private ReviewHelper reviewHelper;


        public ReviewCRUD()
        {
            dalCrud = new RestaurantReviewDataLayer.CRUD.ReviewCRUD();
            reviewHelper = new ReviewHelper();

        }

        public List<RestaurantLibrary.Models.Review> GetAllReviews(int restId)
        {

            ICollection<RestaurantReviewDataLayer.Review> dalRevList = dalCrud.GetAllReviews(restId);
            List<RestaurantLibrary.Models.Review> bllRevList = new List<RestaurantLibrary.Models.Review>();

            foreach (RestaurantReviewDataLayer.Review dalRev in dalRevList)
            {
                bllRevList.Add(reviewHelper.DataToLibrary(dalRev));
            }
            return bllRevList;

        }

        public RestaurantLibrary.Models.Review GetReviewById(int id)
        {
            RestaurantReviewDataLayer.Review dllRev = dalCrud.GetReviewById(id);
            RestaurantLibrary.Models.Review bllRev = reviewHelper.DataToLibrary(dllRev);
            return bllRev;
        }

        public void AddReview(RestaurantLibrary.Models.Review rev)
        {
            RestaurantReviewDataLayer.Review dalRev = reviewHelper.LibraryToData(rev);
            dalCrud.AddReview(dalRev);
        }

        public void UpdateReviewById(RestaurantLibrary.Models.Review rev)
        {
            RestaurantReviewDataLayer.Review dalRev = reviewHelper.LibraryToData(rev);
            dalCrud.UpdateReviewById(dalRev);
        }

        public void DeleteReviewById(int id)
        {
            dalCrud.DeleteReviewById(id);
        }
    }
}
