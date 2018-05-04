using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;

namespace RestaurantLibrary.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Review> Reviewlist;
        public int id { get; set; } 
        public decimal AverageRating { get
            {
            decimal total = 0;
                foreach (Review review in Reviewlist)
                {
                    total += review.Rating;
                }

            return total /= Reviewlist.Count();
            }
            set { }
        }


        public Restaurant(string name, int id)
        {
            this.Name = name;
            this.id = id;
            Reviewlist = new List<Review>();

        }

        public Restaurant()
        { 
        }


        public void AddReview(Review review)
        {
            Reviewlist.Add(review);
        }


        public List<Review> getAllReviews()
        {
            return Reviewlist;
        }
    }
}
