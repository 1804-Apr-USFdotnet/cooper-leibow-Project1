using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;
using RestaurantLibrary.Serializers;
using RestuarantReviewDataLayer;
using NLog;


namespace Project0V2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Restaurant res = new Restaurant("Papa Johns");

            //RestaurantSerializer resSerializer = new RestaurantSerializer();

            //resSerializer.SerializeMethod(res, "restaurant2");

            //RestaurantDeserializer resDeserializer = new RestaurantDeserializer();

            //Console.WriteLine(resDeserializer.DeserializeMethod("restaurant2").AverageRating);

            //Console.ReadKey();



            //Logger log = LogManager.GetCurrentClassLogger();
            //log.Info("Starting application");

            //// start application
            //Console.WriteLine("Welcome to the world of restaurants");
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine();

            //// display menu
            //Console.WriteLine("Here are your options bud: ");
            //Console.WriteLine("\"ViewRev\" (View all restaurants)");
            //Console.WriteLine("\"TopThree\" (Return the top 3 restaurants)");
            //Console.WriteLine("\"ViewRes\" (View a reviews)");
            //Console.WriteLine("\"AddRes\" (Add a restaurant)");



            //Console.Write("Your input: ");
            //String input = Console.ReadLine().ToLower();


            //while(input != "quit")
            //{
            //    if(input == "viewres")
            //    {
            //        Console.WriteLine("How would you like to find the restaurant?");
            //    }
            //    else if(input != "viewres" && input != "topthree" && input != "viewrev" && input != "addres")
            //    {
            //        Console.WriteLine("You messed up bud. Please enter either \"ViewRev\", \"TopThree\", \"ViewRes\", or \"AddRes\"");
            //        Console.Write("<input> ");
            //        input = Console.ReadLine().ToLower();
            //        log.Info(input);

            //    }

            //}

            //// end application
            //Console.WriteLine("peace out dude");

            RestaurantCRUD resCrud = new RestaurantCRUD();
            List<RestaurantLibrary.Models.Restaurant> resList = new List<RestaurantLibrary.Models.Restaurant>(RestaurantListMethods.CreateRestaurantList(resCrud.GetRestaurant()));
            foreach(RestaurantLibrary.Models.Restaurant res in resList)
            {
                Console.WriteLine(res.Name);
                Console.WriteLine(res.AverageRating);
                Console.WriteLine(res.Location);
                res.getAllReviews();
            };

            RestaurantListMethods.TopThree(resList);
            RestaurantListMethods.SortByNameAscending(resList);
            RestaurantListMethods.SortByNameDescending(resList);

            Console.ReadKey();

            
            
            
        }
    }
}
