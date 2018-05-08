using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace RestaurantReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        RestaurantLibrary.CRUD.ReviewCRUD revCrud = new RestaurantLibrary.CRUD.ReviewCRUD();

        

       

        [HttpPost]
        [Route("review/create")]
        public ActionResult Create(RestaurantLibrary.Models.Review rev)
        {
            revCrud.AddReview(rev);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("review/show/{id}")]
        public ViewResult Show(int id)
        {
            RestaurantLibrary.Models.Review rev = revCrud.GetReviewById(id);
            return View(rev);

        }
        [HttpGet]
        [Route("review/edit/{id}")]
        public ViewResult RenderEdit(int id)
        {
            RestaurantLibrary.Models.Review rev = revCrud.GetReviewById(id);
            ViewBag.review = rev;
            return View("edit");

        }

        [HttpPost]
        [Route("review/edit/{id}")]
        public ActionResult Edit(RestaurantLibrary.Models.Review rev, int id)
        {
            revCrud.GetReviewById(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("review/confirmation/{id}")]
        public ActionResult DeleteConfirmation(int id)
        {
            RestaurantLibrary.Models.Review rev = revCrud.GetReviewById(id);
            ViewBag.review = rev;
            return PartialView("_DeleteConfirmation");


        }



        [HttpPost]
        [Route("review/delete/{id}")]
        public ActionResult Delete(int id)
        {

            try
            {
                revCrud.DeleteReviewById(id);
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