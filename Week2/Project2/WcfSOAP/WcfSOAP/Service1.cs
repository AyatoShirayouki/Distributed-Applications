using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public int CalculateDays(int day, int month, int year)
        {
            DateTime dt = new DateTime(year, month, day);
            int datetoday = DateTime.Now.Subtract(dt).Days;

            return datetoday;
        }

        public string GenerateUsername(string value)
        {
            string username = $"user-({value.ToLower()})";

            return username;
        }

        public string GetData(string value)
        {
            if (int.TryParse(value, out _))
            {
                return string.Format("You entered: {0}", value);
            }
            else
            {
                ApplicationService.Class1 service = new ApplicationService.Class1();
                return service.GetData2(value);
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetVignette(string value)
        {
            ApplicationService.Class1 service = new ApplicationService.Class1();
            return service.getBGTollData(value);
        }

        public string GetWeatherData(string value)
        {
            ApplicationService.Class1 service = new ApplicationService.Class1();
            return service.GetWeatherData(value);
        }
    }
}
