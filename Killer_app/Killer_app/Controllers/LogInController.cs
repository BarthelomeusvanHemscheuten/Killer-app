using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Killer_app.Model;

namespace Killer_app.Controllers
{
    public class LogInController : Controller
    {
        private MainController controller = new MainController();
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        //POST : LogIn
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            string mystring = collection["Naam"];
            string otherstring = collection["Wachtwoord"];
            Model.User user = controller.GetUser(collection["Naam"]);
            if (user != null && user.Wachtwoord == collection["Wachtwoord"])
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Shop");
            }
            return View();
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}