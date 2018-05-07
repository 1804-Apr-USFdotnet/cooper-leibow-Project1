using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.LibraryHelper;

namespace RestaurantLibrary.LibraryHelper
{
    public class ReviewHelper
    {
        ReviewerHelper reviewerHelper = new ReviewerHelper();

        // parameter is the EF Restuarant model
        public  RestaurantLibrary.Models.Reviewer DataToLibrary(RestaurantReviewDataLayer.Reviewer reviewer)
        {
            var libModel = new RestaurantLibrary.Models.Reviewer()
            {
               email = reviewer.email,
               name = reviewer.name


            };

            return libModel;
        }

        public  RestaurantReviewDataLayer.Review LibraryToData(RestaurantLibrary.Models.Review libraryReview)
        {
            var dataModel = new RestaurantReviewDataLayer.Review()
            {
                content = libraryReview.Content,
                rating = libraryReview.Rating,
                Reviewer = reviewerHelper.LibraryToData(libraryReview.reviewer)

            };
            return dataModel;
        }
    }
}
