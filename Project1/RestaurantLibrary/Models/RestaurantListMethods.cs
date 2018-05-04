using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;
using RestuarantReviewDataLayer;
using RestaurantLibrary.LibraryHelper;
using NLog;



namespace RestaurantLibrary.Models
{
    public static class RestaurantListMethods
    {
        public static List<Restaurant> CreateRestaurantList(IEnumerable<RestuarantReviewDataLayer.Restaurant> restaurantList)
        {
            List<Restaurant> myList = new List<Restaurant>();

            foreach (var res in restaurantList)
            {
                Restaurant libRes = LibraryHelper.RestaurantHelper.DataToLibrary(res);
                myList.Add(libRes);
            }
            return myList;
        }

        


        public static List<Restaurant> TopThree(List<Restaurant> restaurantList)
        {
            try
            {
                List<Restaurant> myList = restaurantList.OrderBy(o => o.AverageRating).Reverse().ToList();
                return myList;
            }


            catch(Exception e)
            {
                Logger log = LogManager.GetCurrentClassLogger();
                log.Info(e.Message);
                
            }
            return restaurantList;
        }

        public static List<Restaurant> SortByNameAscending(List<Restaurant> restaurantList)
        {
            List<Restaurant> SortedList = restaurantList.OrderBy(o => o.Name).ToList();
            return SortedList;

        }

        public static List<Restaurant> SortByNameDescending(List<Restaurant> restaurantList)
        {
            List<Restaurant> SortedList = restaurantList.OrderBy(o => o.Name).Reverse().ToList();
            return SortedList;


        }

        public static Restaurant GetRestaurantById(List<Restaurant> restaurantList, int ID)
        {
            Restaurant res = restaurantList.Find(r => r.id == ID);
            return res;
        }
    }
}
