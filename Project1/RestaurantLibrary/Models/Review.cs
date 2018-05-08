using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantLibrary.Models
{
    public class Review
    {


        // has a rating and other relevant data(e.g.reviewer name)
        [Range(typeof(decimal), "0", "5")]
        [Required]
        public decimal Rating { get; set; }
        public Reviewer reviewer;
        public int reviewer_id { get; set; }

        [MaxLength(500)]
        [Required]
        public string Content { get; set; }
        public Restaurant restaurant;
        public int restaurant_id { get; set; }
        public int id { get; set; }

       
        public Review(decimal rating, Reviewer reviewer, string content, Restaurant restaurant)
        {
            Rating = rating;
            this.reviewer = reviewer;
            Content = content;
            this.restaurant = restaurant;
        }

        public Review()
        {

        }
    }
}
