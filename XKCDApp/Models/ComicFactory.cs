using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XKCDApp.Models
{
    public static class ComicFactory
    {
        public static Comic CreateFromJson(string jsonString)
        {
            try
            {
                var comic = JsonConvert.DeserializeObject<Comic>(jsonString);
                comic.Date = GetDate(jsonString);
                return comic;
            }
            catch
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