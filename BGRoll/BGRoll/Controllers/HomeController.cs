using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BGRoll.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BGToll(string id)
        {
            var url = "https://check.bgtoll.bg/check/vignette/plate/BG/" + id;

            var client = new WebClient();
            var body = "";

            if (id != null && id != "")
            {
                body = client.DownloadString(url);

                JObject data = JObject.Parse(body);

                if((bool)data["ok"])
                {
                    ViewData["vignetteNumber"] = data["vignette"]["vignetteNumber"];
                    ViewData["validityDateFrom"] = data["vignette"]["validityDateFromFormated"];
                    ViewData["validityDateTo"] = data["vignette"]["validityDateToFormated"];
                }

                ViewData["body"] = body;
            }


            return View();
        }
    }
}