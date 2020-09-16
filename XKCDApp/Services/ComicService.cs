using System;
using System.Net.Http;
using System.Threading.Tasks;
using XKCDApp.Models;

namespace XKCDApp.Services
{
    public class ComicService : IComicService
    {
        private readonly HttpClient _httpClient;

        public ComicService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://xkcd.com/")
            };
        }

        public async Task<Comic> GetComic(int id)
        {
            var response = await _httpClient.GetAsync($"{id}/info.0.json");

            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync();

            return ComicFactory.CreateFromJson(stringContent);
        }
    }
}