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
        RestaurantHelper restaurantHelper = new RestaurantHelper();

        // parameter is the EF Restuarant model
        public  RestaurantLibrary.Models.Review DataToLibrary(RestaurantReviewDataLayer.Review review)
        {
            var libModel = new RestaurantLibrary.Models.Review()
            { 
                Rating = review.rating,
                Content = review.content,
                reviewer = reviewerHelper.DataToLibrary(review.Reviewer),
                restaurant_id = (int)review.restaurant_id,
              
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
                ID = libraryReview.id,
                restaurant_id = libraryReview.restaurant.id,
                reviewer_id = libraryReview.reviewer.id


            };
            return dataModel;
        }
    }
}
