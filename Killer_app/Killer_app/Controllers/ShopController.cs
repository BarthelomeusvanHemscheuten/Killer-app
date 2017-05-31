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
    public class ShopController : Controller
    {
        private MainController controller = new MainController();
        // GET: Shop
        public ActionResult Index(int? page)
        {
            List<Game> games = controller.GetAllGames();
            int pageNumber = (page ?? 1);
            return View(games.ToPagedList(pageNumber, 5));
        }
        public FileContentResult getImg(int id)
        {
            byte[] byteArray = controller.GetGame(id).Image;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpeg")
                : null;
        }
    }
}