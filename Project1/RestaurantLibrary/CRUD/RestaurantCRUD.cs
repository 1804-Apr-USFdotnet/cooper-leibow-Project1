using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;
using RestaurantLibrary.LibraryHelper;
using RestaurantReviewDataLayer;

namespace RestaurantLibrary.CRUD
{
    public class RestaurantCRUD
    {
        private RestaurantReviewDataLayer.RestaurantCRUD dalCrud;
        private RestaurantHelper restHelper;


        public RestaurantCRUD()
        {
            dalCrud = new RestaurantReviewDataLayer.RestaurantCRUD();
            restHelper = new RestaurantHelper();

        }

        public List<RestaurantLibrary.Models.Restaurant> GetAllRestaurant()
        {
            
            List<RestaurantReviewDataLayer.Restaurant> dalRestList = dalCrud.GetAllRestaurant();
            List<RestaurantLibrary.Models.Restaurant> bllRestList = new List<RestaurantLibrary.Models.Restaurant>();

            foreach (RestaurantReviewDataLayer.Restaurant dalRest in dalRestList)
            {
                bllRestList.Add(restHelper.DataToLibrary(dalRest));
            }
            return bllRestList;

        }

        public RestaurantLibrary.Models.Restaurant GetRestaurantById(int id)
        {
            RestaurantReviewDataLayer.Restaurant dllRest = dalCrud.GetRestaurantById(id);
            RestaurantLibrary.Models.Restaurant bllRest =  restHelper.DataToLibrary(dllRest);
            return bllRest;
        }

        public void AddRestaurant(RestaurantLibrary.Models.Restaurant res)
        {
            RestaurantReviewDataLayer.Restaurant dalRest = restHelper.LibraryToData(res);
            dalCrud.AddRestaurant(dalRest);
        }

        public void UpdateRestaurantById(RestaurantLibrary.Models.Restaurant res)
        {
            RestaurantReviewDataLayer.Restaurant dalRest = restHelper.LibraryToData(res);
            dalCrud.UpdateRestaurantById(dalRest);
        }

        public void DeleteRestaurantById(int id)
        {
            dalCrud.DeleteRestaurantById(id);
        }
    }

}
