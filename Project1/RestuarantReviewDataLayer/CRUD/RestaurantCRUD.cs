using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewDataLayer
{
    public class RestaurantCRUD
    {
        private RestaurantDBEntities1 _db;

        public RestaurantCRUD()
        {
            _db = new RestaurantDBEntities1();
        }
        public List<Restaurant> GetAllRestaurant()
        {
            var list = _db.Restaurants.ToList();
            return list;
        }

        public Restaurant GetRestaurantById(int id)
        {
            var res = _db.Restaurants.Find(id);
            return res;
        }

        public void AddRestaurant(Restaurant res)
        {
            _db.Restaurants.Add(res);
            _db.SaveChanges();
        }

        public void UpdateRestaurantById(Restaurant res2)
        {
            Restaurant res1 = _db.Restaurants.Find(res2.ID);
            res1.location = res2.location;
            res1.Name = res2.Name;
            _db.SaveChanges();

        }

        public void DeleteRestaurantById(int id)
        {
            Restaurant res = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(res);
            _db.SaveChanges();
        }
    }

}
