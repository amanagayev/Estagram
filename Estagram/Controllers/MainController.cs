using Estagram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estagram.Controllers
{
    public class MainController : Controller
    {
        public DbModel db = new DbModel();

        public ActionResult Newsfeed()
        {
            return View();
        }
    }
}