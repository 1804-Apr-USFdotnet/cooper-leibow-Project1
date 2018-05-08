using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewDataLayer;
using RestaurantLibrary.LibraryHelper;


namespace RestaurantLibrary.LibraryHelper
{
    public  class ReviewerHelper
    {
        // parameter is the EF Restuarant model
        public  RestaurantLibrary.Models.Reviewer DataToLibrary(RestaurantReviewDataLayer.Reviewer reviewer)
        {
            //var libModel = new RestaurantLibrary.Models.Reviewer()
            //{
            //    name = reviewer.name,
            //    email = reviewer.email,
            //    id = reviewer.ID

            //};
            var libModel = new RestaurantLibrary.Models.Reviewer();
            libModel.name = reviewer.name;
            libModel.email = reviewer.email;
            libModel.id = reviewer.ID;

            return libModel;
        }

        public  RestaurantReviewDataLayer.Reviewer LibraryToData(RestaurantLibrary.Models.Reviewer libraryReviewer)
        {
            var dataModel = new RestaurantReviewDataLayer.Reviewer();
            dataModel.email = libraryReviewer.email;
            dataModel.name = libraryReviewer.name;
            dataModel.ID = libraryReviewer.id;
            
       
            return dataModel;
        }
    }
}
