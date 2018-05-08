using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using RestaurantLibrary.Models;

namespace RestaurantReviews.Web.Controllers
{
    public class RestaurantController : Controller
    {
        RestaurantLibrary.CRUD.RestaurantCRUD resCrud = new RestaurantLibrary.CRUD.RestaurantCRUD();
        RestaurantListMethods resMethods = new RestaurantListMethods();

        [Route("restaurant/index")]
        public ActionResult Index()
        {
            ViewBag.restaurants = resCrud.GetAllRestaurant();

            if(TempData["topThreeList"] != null)
            {
                ViewBag.restaurants = TempData["topThreeList"];
            }

            if (TempData["nameAscendingList"] != null)
            {
                ViewBag.restaurants = TempData["nameAscendingList"];
            }

            if (TempData["search"] != null)
            {
                ViewBag.restaurants = TempData["search"]; 
            }
            
            return View();
        }

        [HttpGet]
        [Route("restaurant/new")]
        public ActionResult New()
        {
            return View("new");
        }

        [HttpPost]
        [Route("restuarant/create")]
        public ActionResult Create(RestaurantLibrary.Models.Restaurant res)
        {
            resCrud.AddRestaurant(res);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("restaurant/show/{id}")]
        public ViewResult Show(int id)
        {
            Restaurant res = resCrud.GetRestaurantById(id);
            RestaurantLibrary.CRUD.ReviewerCRUD reviewerCRUD = new RestaurantLibrary.CRUD.ReviewerCRUD();
            RestaurantListMethods restListMethods = new RestaurantListMethods();

            ViewData["reviewers"] = reviewerCRUD.GetAllReviewers();
            ViewData["restaurant_id"] = id;
            ViewData["restaurant_reviews"] = res.Reviewlist;
            ViewBag.restaurant = res;
            
            return View("view");

        }
        [HttpGet]
        [Route("restaurant/edit/{id}")]
        public ViewResult RenderEdit(int id)
        {
            Restaurant res = resCrud.GetRestaurantById(id);
            ViewBag.restaurant = res;
            return View("edit");

        }

        [HttpPost]
        [Route("restaurant/edit/{id}")]
        public ActionResult Edit(Restaurant res)
        {
            resCrud.UpdateRestaurantById(res);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("restaurant/confirmation/{id}")]
        public ActionResult DeleteConfirmation(int id)
        {
            Restaurant res = resCrud.GetRestaurantById(id);
            ViewBag.restaurant = res;
            return PartialView("_DeleteConfirmation");


        }



        [HttpPost]
        [Route("restaurant/delete/{id}")]
        public ActionResult Delete(int id)
        {
            
            try
            {
                resCrud.DeleteRestaurantById(id);
            }
            catch (NullReferenceException e) 
            {
                Logger log = LogManager.GetCurrentClassLogger();
                log.Info(e.Message);
                TempData.Add("error", e.Message);
                

            }
            return RedirectToAction("index");
        }

 

        [HttpGet]
        [Route("restaurant/topthree")]
        public ActionResult TopThree()
        {
            List<Restaurant> myRest = resCrud.GetAllRestaurant();
            List<Restaurant> topThreeList = resMethods.TopThree(myRest);
            TempData["topThreeList"] = topThreeList;
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("restaurant/ascending")]
        public ActionResult NameAscending()
        {
            List<Restaurant> myRest = resCrud.GetAllRestaurant();
            List<Restaurant> nameAscendingList = resMethods.SortByNameAscending(myRest);
            TempData["nameAscendingList"] = nameAscendingList;
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("restaurant/descending")]
        public ActionResult NameDescending()
        {
            List<Restaurant> myRest = resCrud.GetAllRestaurant();
            List<Restaurant> nameAscendingList = resMethods.SortByNameDescending(myRest);
            TempData["nameAscendingList"] = nameAscendingList;
            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("restaurant/search")]
        public ActionResult NameDescending(FormCollection form)
        {
            List<Restaurant> myRest = resCrud.GetAllRestaurant();
            List<Restaurant> searchedList = resMethods.Search(myRest, Request.Form["search_info"]);
            TempData["search"] = searchedList;
            return RedirectToAction("index");
        }

       
    }

}