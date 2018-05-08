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
            RestaurantLibrary.Models.Review review = new RestaurantLibrary.Models.Review();
            review.Rating = Decimal.Parse(Request.Form["rating"]);
            review.Content = Request.Form["content"];
            review.restaurant = restaurantCrud.GetRestaurantById(Int32.Parse(Request.Form["restaurant_id"]));
            review.reviewer = reviewerCrud.GetReviewerById(Int32.Parse(Request.Form["reviewer_id"]));

            //RestaurantLibrary.Models.Restaurant restaurant = restaurantCrud.GetRestaurantById(Int32.Parse(form["restaurant_id"]));
            //RestaurantLibrary.Models.Reviewer reviewer = reviewerCrud.GetReviewerById(Int32.Parse(form["reviewer_id"]));

            //rev.reviewer.id = Int32.Parse(form["reviewer_id"]);
            //rev.reviewer = reviewer;
            //rev.restaurant = restaurant;

            revCrud.AddReview(review);
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
            ViewData["restaurant_id"] = rev.restaurant_id;
            
            ViewData["reviewer_id"] = rev.reviewer_id;
            return View("edit");

        }

        [HttpPost]
        [Route("review/edit/{id}")]
        public ActionResult Edit(RestaurantLibrary.Models.Review rev, FormCollection form)

        {
            RestaurantLibrary.Models.Review review = revCrud.GetReviewById(rev.id);
            review.Rating = Decimal.Parse(Request.Form["rating"]);
            review.Content = Request.Form["content"];
            review.restaurant = restaurantCrud.GetRestaurantById(Int32.Parse(Request.Form["restaurant_id"]));
            review.reviewer = reviewerCrud.GetReviewerById(Int32.Parse(Request.Form["reviewer_id"]));
            revCrud.UpdateReviewById(review);
            return RedirectToAction("index", "restaurant");
        }

        [HttpGet]
        [Route("review/confirmation/{id}")]
        public ActionResult DeleteConfirmation(int id)
        {
            RestaurantLibrary.Models.Review rev = revCrud.GetReviewById(id);
            ViewBag.review = rev;
            return PartialView("_DeleteConfirmationReview");


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
            return RedirectToAction("index", "restaurant");
        }

        
    }
}