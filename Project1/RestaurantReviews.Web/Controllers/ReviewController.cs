using NLog;
using System;
using System.Web.Mvc;

namespace RestaurantReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        RestaurantLibrary.CRUD.ReviewCRUD revCrud = new RestaurantLibrary.CRUD.ReviewCRUD();
        RestaurantLibrary.CRUD.ReviewerCRUD reviewerCrud = new RestaurantLibrary.CRUD.ReviewerCRUD();
        RestaurantLibrary.CRUD.RestaurantCRUD restaurantCrud = new RestaurantLibrary.CRUD.RestaurantCRUD();






        [HttpPost]
        [Route("review/create")]
        public ActionResult Create(RestaurantLibrary.Models.Review rev, FormCollection form)
        {
            RestaurantLibrary.Models.Restaurant restaurant = restaurantCrud.GetRestaurantById(Int32.Parse(form["restaurant_id"]));
            RestaurantLibrary.Models.Reviewer reviewer = reviewerCrud.GetReviewerById(Int32.Parse(form["reviewer_id"]));

            //rev.reviewer.id = Int32.Parse(form["reviewer_id"]);
            rev.reviewer = reviewer;
            rev.restaurant = restaurant;

            revCrud.AddReview(rev);
            return RedirectToAction("Index", "Restaurant");
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