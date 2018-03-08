using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hfttfSozluk.Controllers
{
    public class PostDetailController : Controller
    {
        // GET: PostDetail
        public ActionResult Index(int id)
        {
            ViewBag.gonderiId = id;
            return View();
        }
    }
}