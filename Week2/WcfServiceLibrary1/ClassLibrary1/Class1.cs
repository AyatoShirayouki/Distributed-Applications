using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public string Sample(string id)
        {
            var bgTollUrl = "https://check.bgtoll.bg/check/vignette/plate/BG/";

            var client = new WebClient();
            var body = "";


            if (id != null && id != "")
            {

                body = client.DownloadString(bgTollUrl + id);
                /*
                body = client.DownloadString(bgTollUrl + id);
                JObject data = JObject.Parse(body);
                ViewData["ok"] = (bool)data["ok"];
                if ((bool)data["ok"])
                {
                    ViewData["country"] = (string)data["vignette"]["country"];
                    ViewData["vignetteNumber"] = (string)data["vignette"]["vignetteNumber"];
                    ViewData["validityDateFromFormated"] = (string)data["vignette"]["validityDateFromFormated"];
                    ViewData["validityDateToFormated"] = (string)data["vignette"]["validityDateToFormated"];
                }
                */
            }

            return "data: "+body;
            
        }

    }
}
