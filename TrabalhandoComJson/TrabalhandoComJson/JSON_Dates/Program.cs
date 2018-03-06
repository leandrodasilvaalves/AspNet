using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new Log
            {
                Details = "App start",
                LogDate = new DateTime(2018, 02, 06)
            };
            Console.WriteLine(JsonConvert.SerializeObject(log));

            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            Console.WriteLine(JsonConvert.SerializeObject(log, microsoftDateFormatSettings));
            Console.WriteLine(JsonConvert.SerializeObject(log, new JavaScriptDateTimeConverter()));

            Console.ReadKey();
        }
    }
}
