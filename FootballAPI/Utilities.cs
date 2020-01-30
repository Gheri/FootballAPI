using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI
{
    // Utilities class would contain common helper methods
    public static class Utilities
    {
        public static T GetData<T>(string jsonFile)
        {
            StreamReader sr = new StreamReader(jsonFile);
            string jsonString = sr.ReadToEnd();
           return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string GetDateTimeStringInISO8601(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}
