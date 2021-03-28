using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estagram.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Content()
        {
            return View();
        }
    }
}