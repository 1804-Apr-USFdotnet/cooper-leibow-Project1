using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantReviews.Web.Controllers
{
    public class ReviewerController : Controller
    {
        RestaurantLibrary.CRUD.ReviewerCRUD reviewerCrud = new RestaurantLibrary.CRUD.ReviewerCRUD();

      

        [HttpGet]
        [Route("reviewer/new")]
        public ActionResult New()
        {
            return View("new");
        }

        [HttpPost]
        [Route("reviewer/create")]
        public ActionResult Create(FormCollection form)
        {
            RestaurantLibrary.Models.Reviewer reviewer = new RestaurantLibrary.Models.Reviewer();
            reviewer.name = form["name"];
            reviewer.email = form["email"];
            reviewerCrud.AddReview(reviewer);
            return RedirectToAction("Index", "Restaurant");
        }
    }
}