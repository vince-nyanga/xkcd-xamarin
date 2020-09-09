using System;
using Newtonsoft.Json;

namespace XKCDApp.Models
{
    public class Comic
    {
        public DateTime Date { get; set; }

        [JsonProperty("safe_title")]
        public string SafeTitle { get; set; }

        [JsonProperty("transcript")]
        public string Transcript { get; set; }

        [JsonProperty("alt")]
        public string AlternateText { get; set; }

        [JsonProperty("img")]
        public string ImageUrl { get; set; }
    }
}
