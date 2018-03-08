using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hfttfSozluk.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index(string id)
        {
            ViewBag.kulAdi = id;
            return View();
        }
    }
}