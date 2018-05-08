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
        public  RestaurantLibrary.Models.Review DataToLibrary(RestaurantReviewDataLayer.Review review)
        {
            var libModel = new RestaurantLibrary.Models.Review()
            { 
                Rating = review.rating,
                Content = review.content,
                reviewer = reviewerHelper.DataToLibrary(review.Reviewer),
                id = review.ID
                

            };

            return libModel;
        }

        public  RestaurantReviewDataLayer.Review LibraryToData(RestaurantLibrary.Models.Review libraryReview)
        {
            var dataModel = new RestaurantReviewDataLayer.Review()
            {
                content = libraryReview.Content,
                rating = libraryReview.Rating,
                Reviewer = reviewerHelper.LibraryToData(libraryReview.reviewer),
                ID = libraryReview.id

            };
            return dataModel;
        }
    }
}
