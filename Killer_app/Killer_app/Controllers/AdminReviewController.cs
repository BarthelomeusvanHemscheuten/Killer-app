using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Killer_app.Data;
using Killer_app.Logic;
using Killer_app.Model;
using PagedList;

namespace Killer_app.Controllers
{
    public class AdminReviewController : Controller
    {
        private MainController controller = new MainController();
        // GET: AdminReview
        public ActionResult Index(int? page)
        {
            List<Review> reviews = controller.GetAllReviews();
            int pageNumber = (page ?? 1);
            return View(reviews.ToPagedList(pageNumber, 10));
        }
    }
}