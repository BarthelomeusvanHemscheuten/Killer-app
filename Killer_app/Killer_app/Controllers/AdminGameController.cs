using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Killer_app.Model;
using Killer_app.Logic;
using Killer_app.Data;
using PagedList;

namespace Killer_app.Controllers
{
    public class AdminGameController : Controller
    {
        private MainController controller = new MainController();
        // GET: Shop
        public ActionResult Index(int? page)
        {
            List<Game> games = controller.GetAllGames();


            int pageNumber = (page ?? 1);
            return View(games.ToPagedList(pageNumber, 6));
        }
        //GET: Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Game game = controller.GetGame((int)id);
            return View(game);
        }
        //POST: Delete/id
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (controller.DeleteGame(id))
            {
                return RedirectToAction("Index");
            }
            else{ return View(controller.GetGame(id)); }
        }
        //GET: Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Game game = controller.GetGame((int)id);
            return View(game);
        }
        //POST: Edit/id
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            Game game = controller.GetGame(Convert.ToInt32(collection["ID"]));
            byte[] picture = null;
            HttpPostedFileBase file = Request.Files["file"];
            if (file.ContentLength != 0)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    picture = ms.GetBuffer();
                }
            }
            else { picture = game.Image; }
            try
            {
                if (game.EditGame(collection["Naam"], Convert.ToDecimal(collection["Prijs"]), collection["Trailer"], Convert.ToDecimal(collection["Score"]), picture, Convert.ToDecimal(collection["OudePrijs"])))
                {
                    return RedirectToAction("Index");
                }
                else{ return View(game); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
        //POST : Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //Gets the file and converts into a byte array
            HttpPostedFileBase file = Request.Files["file"];
            byte[] picture = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                picture = ms.GetBuffer();
            }
            //Inserts data from formcollection and from image
            if (controller.InsertGame(new Game(collection["Naam"], Convert.ToDecimal(collection["Prijs"]), collection["Trailer"], Convert.ToDecimal(collection["Score"]), picture)))
            {
                return RedirectToAction("Index");
            }
            else{ return View(); }
        }

    }
}