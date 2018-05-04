using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary.LibraryHelper
{
    public static class ReviewHelper
    {
        // parameter is the EF Restuarant model
        public static RestaurantLibrary.Models.Review DataToLibrary(RestuarantReviewDataLayer.Review review)
        {
            var libModel = new RestaurantLibrary.Models.Review()
            {
                Content = review.content,
                Rating = review.rating,
                reviewer = ReviewerHelper.DataToLibrary(review.Reviewer)


            };

            return libModel;
        }

        public static RestuarantReviewDataLayer.Review LibraryToData(RestaurantLibrary.Models.Review libraryReview)
        {
            var dataModel = new RestuarantReviewDataLayer.Review()
            {
                content = libraryReview.Content,
                rating = libraryReview.Rating,
                Reviewer = ReviewerHelper.LibraryToData(libraryReview.reviewer)

            };
            return dataModel;
        }
    }
}
