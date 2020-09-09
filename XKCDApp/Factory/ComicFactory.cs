using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XKCDApp.Models;

namespace XKCDApp.Factory
{
    public static class ComicFactory
    {
        public static Comic FromJson(string jsonString)
        {
            try
            {
                var comic = JsonConvert.DeserializeObject<Comic>(jsonString);
                comic.Date = GetDate(jsonString);
                return comic;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static DateTime GetDate(string jsonString)
        {
            var jObject = JObject.Parse(jsonString);
            var year = int.Parse(jObject["year"].ToString());
            var month = int.Parse(jObject["month"].ToString());
            var day = int.Parse(jObject["day"].ToString());
            return new DateTime(year, month, day);
        }
    }
}
