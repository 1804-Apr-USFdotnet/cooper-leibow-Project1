using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestuarantReviewDataLayer;
using RestaurantLibrary.LibraryHelper;


namespace RestaurantLibrary.LibraryHelper
{
    public static class ReviewerHelper
    {
        // parameter is the EF Restuarant model
        public static RestaurantLibrary.Models.Reviewer DataToLibrary(RestuarantReviewDataLayer.Reviewer reviewer)
        {
            var libModel = new RestaurantLibrary.Models.Reviewer()
            {
                name = reviewer.name,
                email = reviewer.email


            };

            return libModel;
        }

        public static RestuarantReviewDataLayer.Reviewer LibraryToData(RestaurantLibrary.Models.Reviewer libraryReviewer)
        {
            var dataModel = new RestuarantReviewDataLayer.Reviewer()
            {
                name = libraryReviewer.name,
                email = libraryReviewer.email
            };
            return dataModel;
        }
    }
}
