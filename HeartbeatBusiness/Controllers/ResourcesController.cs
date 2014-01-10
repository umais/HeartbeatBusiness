using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeartbeatBusiness.Controllers
{
    public class ResourcesController : Controller
    {
        //
        // GET: /Resources/

        public ActionResult Manifest()
        {
            var manifestResult = new ManifestResult("1.0")
            {
                CacheResources = new List<string>() 
             {
                   Url.Action("Index", "Home"),
                   "/content/Angular/angular.js",
                   "/content/Angular/app.js",
                   "/content/Angular/HeartbeatService.js",
                   "/content/Angular/HeartbeatController.js",
                   "/content/Angular/HeartbeatController.js",
             },
                NetworkResources = new string[] { Url.Action("Status", "Service") },
                FallbackResources = { { "/logo.png", "/logo_offline.png" } }
            };
            return manifestResult;
        }

    }
}
