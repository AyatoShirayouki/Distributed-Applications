using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class Class1
    {
        public string GetData2(string something)
        {
            return $"this is from ApplicationService: {something}";
        }

        public string getBGTollData(string number)
        {
            var BGTollUrl = "https://check.bgtoll.bg/check/vignette/plate/BG/";

            var client = new WebClient();
            var body = "";

            if (number != null && number != "")
            {
                body = client.DownloadString(BGTollUrl + number);
            }
            else
            {
                body = "Please Enter a valid number";
            }

            return body;
        }

        public string GetWeatherData(string value)
        {
            var apiKey = "5ffbb93167cc7ee4268280a91816020d";
            var url = "http://api.openweathermap.org/data/2.5/weather?q="+value+"&appid="+apiKey;
            
            var client = new WebClient();
            var body = "";

            try
            {
                body = client.DownloadString(url);
            }
            catch (Exception)
            {
                return "Enter a valid City";
            }

            JObject data = JObject.Parse(body);
            double celsius = (double)data["main"]["temp"];
            celsius -= 272.15;

            string temp = celsius.ToString();

            if (temp != null && temp != "")
            {
                return $"Temperature in {value} is: {temp}C";
            }
            else
            {
                return "Something went whrong";
            }
        }
    }
}
