using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewDataLayer;
using RestaurantLibrary.Models;
using RestaurantLibrary.LibraryHelper;


namespace RestaurantLibrary.LibraryHelper
{
    public  class RestaurantHelper 
    {

        // parameter is the EF Restuarant model
        public  RestaurantLibrary.Models.Restaurant DataToLibrary(RestaurantReviewDataLayer.Restaurant data)
        {
            List<RestaurantLibrary.Models.Review> emptyList = new List<RestaurantLibrary.Models.Review>();
            ReviewHelper reviewHelper = new ReviewHelper();


            // convert data Review to model Review
            foreach (RestaurantReviewDataLayer.Review rev in data.Reviews)
            {
                emptyList.Add(reviewHelper.DataToLibrary(rev));
            }

            var libModel = new RestaurantLibrary.Models.Restaurant()
            {
                Name = data.Name,
                Location = data.location,
                Reviewlist = emptyList,
                id = data.ID
                
                

            };
            
            return libModel;
        }

        public  RestaurantReviewDataLayer.Restaurant LibraryToData(RestaurantLibrary.Models.Restaurant data)
        {
            List<RestaurantReviewDataLayer.Review> emptyList = new List<RestaurantReviewDataLayer.Review>();
            ReviewHelper reviewHelper = new ReviewHelper();

            // convert data Review to model Review
            if(data.Reviewlist!= null)
            {
                foreach (RestaurantLibrary.Models.Review rev in data.Reviewlist)
                {
                    emptyList.Add(reviewHelper.LibraryToData(rev));
                }
            }
          

            var libModel = new RestaurantReviewDataLayer.Restaurant()
            {
                Name = data.Name,
                location = data.Location,
                Reviews = emptyList,
                ID = data.id



            };

            return libModel;
        }
    }
}
