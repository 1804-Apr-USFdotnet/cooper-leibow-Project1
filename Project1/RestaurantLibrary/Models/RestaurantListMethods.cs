using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;
using RestaurantReviewDataLayer;
using RestaurantLibrary.LibraryHelper;
using NLog;



namespace RestaurantLibrary.Models
{
    public class RestaurantListMethods
    {
        RestaurantLibrary.LibraryHelper.RestaurantHelper resHelper = new RestaurantLibrary.LibraryHelper.RestaurantHelper();

        public  List<Restaurant> CreateRestaurantList(IEnumerable<RestaurantReviewDataLayer.Restaurant> restaurantList)
        {
            List<Restaurant> myList = new List<Restaurant>();

            foreach (var res in restaurantList)
            {
                Restaurant libRes = resHelper.DataToLibrary(res);
                myList.Add(libRes);
            }
            return myList;
        }

        


        public  List<Restaurant> TopThree(List<Restaurant> restaurantList)
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

        public  List<Restaurant> SortByNameAscending(List<Restaurant> restaurantList)
        {
            List<Restaurant> SortedList = restaurantList.OrderBy(o => o.Name).ToList();
            return SortedList;

        }

        public  List<Restaurant> SortByNameDescending(List<Restaurant> restaurantList)
        {
            List<Restaurant> SortedList = restaurantList.OrderBy(o => o.Name).Reverse().ToList();
            return SortedList;


        }

        public  Restaurant GetRestaurantById(List<Restaurant> restaurantList, int ID)
        {
            Restaurant res = restaurantList.Find(r => r.id == ID);
            return res;
        }

        public List<Restaurant> Search(List<Restaurant> restaurantList, string substring)
        {
            List<Restaurant> SortedList = new List<Restaurant>();
            foreach (Restaurant res in restaurantList)
            {
                if (res.Name.ToLower().Contains(substring.ToLower()))
                {
                    SortedList.Add(res);
                }
            }
            return SortedList;
        }

        //public IEnumerable<Review> FindReviewsWithResId(Restaurant res)
        //{
        //    IEnumerable<Review> revList;
        //    revList = res.Reviewlist.Where(r => r.restaurant.id == res.id);
        //    return revList;
        //}
    }
}
