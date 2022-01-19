using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_FINAL_TEST.Controllers
{
    public class CheifController : Controller
    {
        // GET: Cheif
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowChief()
        {
            ViewBag.HelloChief = "Hello Chief !";
            return View();
        }
    }
}