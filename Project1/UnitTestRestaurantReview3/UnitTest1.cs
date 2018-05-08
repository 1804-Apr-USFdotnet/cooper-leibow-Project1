using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantLibrary.Models;
using RestaurantLibrary.Serializers;
using System.Collections.Generic;


namespace UnitTestRestaurantReview3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReviewConstructorTest()
        {
            Reviewer reviewer = new Reviewer("Cooper", "leibowcooper@gmail.com");
            string expected = "Cooper";

            var actual = reviewer.name;

            Assert.AreEqual(expected, actual);



        }
        // test getAvgrating can add one value and obtain average
        [TestMethod]
        public void SingleValueAverageRatingTest()
        {
            // arrange
            Reviewer reviewer = new Reviewer("Cooper", "leibowcooper@gmail.com");
            Restaurant restaurant = new Restaurant("Popeyes", 1);
            reviewer.MakeReview(4.35m, restaurant, "I really liked it");

            decimal expected = 4.35m;
       
             
            // act
            var actual = restaurant.AverageRating;

            //assert
            Assert.AreEqual(expected, actual);

        }

        // test get avg rating can add more than one value and get average
        [TestMethod]
        public void MultipleValueAverageRatingTest()
        {
            Reviewer reviewer = new Reviewer("Cooper", "leibowcooper@gmail.com");
            Restaurant restaurant = new Restaurant("the Krusty Krab", 1);
            reviewer.MakeReview(3.4m, restaurant, "it was a good place to eat");
            reviewer.MakeReview(4.5m, restaurant, "food wams amazinggggg");

            decimal expected = 3.95m;

            var actual = restaurant.AverageRating;

            Assert.AreEqual(expected, actual);
        }
        
        // test to ensure deserializer can obtain restaurant name
        [TestMethod]
        public void SerializationTest()
        {
            Restaurant restaurant = new Restaurant("the Krusty Krab", 1);
            Reviewer reviewer = new Reviewer("Cooper", "leibowcooper@gmail.com");
            reviewer.MakeReview(3.4m, restaurant, "it was a good place to eat");
            reviewer.MakeReview(4.5m, restaurant, "food wams amazinggggg");

            RestaurantSerializer.SerializeMethod(restaurant, "test_file");

            Restaurant deserialRes = RestaurantDeserializer.DeserializeMethod("test_file");

            string expected = "the Krusty Krab";

            var actual = deserialRes.Name;

            Assert.AreEqual(expected, actual);

        }

        // Test to ensure getRestaurantById method 
        //[TestMethod]
        //public void SortRestaurantByIdTest()
        //{
        //    Restaurant res1 = new Restaurant("Burger King", 1);
        //    Restaurant res2 = new Restaurant("McDonalds", 2);
        //    Restaurant res3 = new Restaurant("Wendys", 3);
        //    List<Restaurant> myList = new List<Restaurant>();
        //    myList.Add(res1);
        //    myList.Add(res2);
        //    myList.Add(res3);

        //    Restaurant foundRes = RestaurantListMethods.GetRestaurantById(myList, 1);
            
         
        //    string expected = "Burger King";

        //    string actual = foundRes.Name;

        //    Assert.AreEqual(actual, expected);


        //}

        //[TestMethod]
        //public void SortByNameAscending()
        //{
        //    Restaurant res1 = new Restaurant("Burger King", 1);
        //    Restaurant res2 = new Restaurant("McDonalds", 2);
        //    Restaurant res3 = new Restaurant("Wendys", 3);
        //    Restaurant res4 = new Restaurant("Checkers", 4);

        //    Reviewer reviewer = new Reviewer("Cooper", "leibowcooper@gmail.com");
        //    reviewer.MakeReview(4.35m, res1, "I really liked it");
        //    reviewer.MakeReview(3.67m, res2, "It was ok");
        //    reviewer.MakeReview(4.87m, res3, "Sooooo good");
        //    reviewer.MakeReview(2.34m, res4, "holy crap so bad");



        //    List<Restaurant> myList = new List<Restaurant>();
        //    myList.Add(res1);
        //    myList.Add(res2);
        //    myList.Add(res3);
        //    myList.Add(res4);

        //    List<Restaurant> sortedList = RestaurantListMethods.SortByNameAscending(myList);

        //    int expected = 1;

        //    int actual = sortedList.IndexOf(res4);


        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void SortByNameDescendingTest()
        //{
        //    Restaurant res1 = new Restaurant("Burger King", 1);
        //    Restaurant res2 = new Restaurant("McDonalds", 2);
        //    Restaurant res3 = new Restaurant("Wendys", 3);
        //    Restaurant res4 = new Restaurant("Checkers", 4);

        //    Reviewer reviewer = new Reviewer("Cooper", "leibowcooper@gmail.com");
        //    reviewer.MakeReview(4.35m, res1, "I really liked it");
        //    reviewer.MakeReview(3.67m, res2, "It was ok");
        //    reviewer.MakeReview(4.87m, res3, "Sooooo good");
        //    reviewer.MakeReview(2.34m, res4, "holy crap so bad");



        //    List<Restaurant> myList = new List<Restaurant>();
        //    myList.Add(res1);
        //    myList.Add(res2);
        //    myList.Add(res3);
        //    myList.Add(res4);

        //    List<Restaurant> sortedList = RestaurantListMethods.SortByNameDescending(myList);

        //    int expected = 1;

        //    int actual = sortedList.IndexOf(res2);


        //    Assert.AreEqual(expected, actual);


        //}

        //[TestMethod]
        //public void TopThreeTest()
        //{
        //    Restaurant res1 = new Restaurant("Burger King", 1);
        //    Restaurant res2 = new Restaurant("McDonalds", 2);
        //    Restaurant res3 = new Restaurant("Wendys", 3);
        //    Restaurant res4 = new Restaurant("Checkers", 4);

        //    Reviewer reviewer = new Reviewer("Cooper", "leibowcooper@gmail.com");
        //    reviewer.MakeReview(4.35m, res1, "I really liked it");
        //    reviewer.MakeReview(3.67m, res2, "It was ok");
        //    reviewer.MakeReview(4.87m, res3, "Sooooo good");
        //    reviewer.MakeReview(2.34m, res4, "holy crap so bad");



        //    List<Restaurant> myList = new List<Restaurant>();
        //    myList.Add(res1);
        //    myList.Add(res2);
        //    myList.Add(res3);
        //    myList.Add(res4);

        //    List<Restaurant> sortedList = RestaurantListMethods.TopThree(myList);


        //    int expected = 0;

        //    int actual = sortedList.IndexOf(res3);


        //    Assert.AreEqual(expected, actual);

        //}

        [TestMethod]
        public void GetAllReviewsTest()
        {
            Restaurant res1 = new Restaurant("Burger King", 1);


            Reviewer reviewer = new Reviewer("Cooper", "leibowcooper@gmail.com");
            Review review1 = new Review(4.35m, reviewer, "I really liked it", res1);
            Review review2 = new Review(3.37m, reviewer, "It was ok", res1);
            res1.AddReview(review1);
            res1.AddReview(review2);
            List<Review> reviewList = res1.getAllReviews();

            Review expected = review1;


            Review actual = reviewList[0];


            Assert.AreEqual(expected, actual);

        }

    }
}
