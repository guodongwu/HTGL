
using HTGL.Model;
using HTGL.Service.Implement;
using HTGL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTGL.UI.Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Manage","Cms");

        }
    }
}
