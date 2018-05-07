using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        RestaurantLibrary.CRUD.ReviewCRUD revCrud = new RestaurantLibrary.CRUD.ReviewCRUD();

        

        [HttpGet]
        [Route("restaurant/details/{}")]
        public ActionResult New(int restaurant_id)
        {
            
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
            return View(res);

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

        
    }
}