using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Killer_app.Model;

namespace Killer_app.Controllers
{
    public class ProfielController : Controller
    {
        private MainController controller = new MainController();
        // GET: Profiel
        
        public ActionResult Index()
        {
            User user = Session["user"] as User;
            Profiel profiel = user.Profiel;
            return View(profiel);
        }
        public ActionResult Edit()
        {
            User user = Session["user"] as User;
            Profiel profiel = user.Profiel;
            return View(profiel);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            User user = Session["user"] as User;
            HttpPostedFileBase file = Request.Files["file"];
            byte[] picture = null;
            if (file.ContentLength != 0)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    picture = ms.GetBuffer();
                }
            }
            else { picture = user.Profiel.Foto; }
            if(user.Profiel.EditProfiel(collection["Naam"], collection["Description"], picture))
            {
                return RedirectToAction("Index", "Profiel");
            }
            return View();
        }
        public FileContentResult getImg(int id)
        {
            byte[] byteArray = controller.GetProfiel(id).Foto;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpeg")
                : null;
        }

    }
}