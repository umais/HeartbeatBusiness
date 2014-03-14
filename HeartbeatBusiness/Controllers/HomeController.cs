using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeartbeatBusiness.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            string url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            ViewBag.URI = url;
            return View();
        }


        public ActionResult TimeSheet()
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            return View();
        }
        public ActionResult OfflineEvents()
        {
            return View();
        }

        public ActionResult InvoiceView()
        {
            return View();
        }


        
    }
}
