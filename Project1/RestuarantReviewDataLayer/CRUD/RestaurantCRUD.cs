using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantReviewDataLayer
{
    public class RestaurantCRUD
    {
        //public async Task AddRestaurant(Restaurant res)
        //{
        //    using (var db = new RestaurantDBEntities())
        //    {
        //        db.Restaurants.Add(res);
        //        await db.SaveChangesAsync();
        //    }
        //}

        private RestaurantDBEntities1 _db;

        public RestaurantCRUD()
        {
            _db = new RestaurantDBEntities1();
        }

        public IEnumerable<Restaurant> GetAllRestaurant()
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

        public void UpdateResById(int id, string column, string change)
        {
            Restaurant res = _db.Restaurants.Find(id);
            switch (column.ToLower())
            {
                case "name":
                    res.Name = change;
                    break;

                case "location":
                    res.location= change;
                    break;

                
            }
            _db.SaveChanges();

        }

        public void DeleteResById(int id)
        {
            Restaurant res = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(res);
            _db.SaveChanges();
        }
    }

}
