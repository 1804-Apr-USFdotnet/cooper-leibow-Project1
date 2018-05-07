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
        public ActionResult Create(RestaurantLibrary.Models.Reviewer reviewer)
        {
            reviewerCrud.AddReview(reviewer);
            return RedirectToAction("Index");
        }
    }
}