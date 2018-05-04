using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestuarantReviewDataLayer;
using RestaurantLibrary.Models;
using RestaurantLibrary.LibraryHelper;


namespace RestaurantLibrary.LibraryHelper
{
    public static class RestaurantHelper 
    {

        // parameter is the EF Restuarant model
        public static RestaurantLibrary.Models.Restaurant DataToLibrary(RestuarantReviewDataLayer.Restaurant data)
        {
            List<RestaurantLibrary.Models.Review> emptyList = new List<RestaurantLibrary.Models.Review>();

            // convert data Review to model Review
            foreach (RestuarantReviewDataLayer.Review rev in data.Reviews)
            {
                emptyList.Add(ReviewHelper.DataToLibrary(rev));
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

        //public static RestuarantReviewDataLayer.Restaurant LibraryToData(RestaurantLibrary.Models.Restaurant libraryRes)
        //{
        //    List<RestuarantReviewDataLayer.Restaurant> emptyList = new List<RestuarantReviewDataLayer.Restaurant>();

        //    foreach (RestaurantLibrary.Models.Review modelRev in libraryRes.Reviewlist)
        //    {
        //        emptyList.Add(ReviewHelper.LibraryToData(modelRev));
        //    }

        //    var dataModel = new RestuarantReviewDataLayer.Restaurant()
        //    {
        //        Name = libraryRes.Name,
        //        location = libraryRes.Location
        //    };
        //    return dataModel;
        //}
    }
}
