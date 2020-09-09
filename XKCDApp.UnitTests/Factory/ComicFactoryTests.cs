using Newtonsoft.Json.Linq;
using XKCDApp.Factory;
using Xunit;

namespace XKCDApp.UnitTests.Factory
{
    public class ComicFactoryTests
    {
        [Fact]
        public void FromJson_WithValidString_ShouldReturnComic()
        {
            var jsonString = GetValidString();

            var comic = ComicFactory.FromJson(jsonString);

            Assert.NotNull(comic);
            Assert.Equal(2020, comic.Date.Year);
            Assert.Equal("http://test.com/", comic.ImageUrl.AbsoluteUri);
        }

        [Fact]
        public void FromJson_WithInvalidString_ShouldNotReturnComic()
        {
            var jsonString = "invalid";

            var comic = ComicFactory.FromJson(jsonString);

            Assert.Null(comic);
        }

        private string GetValidString()
        {
            var jobject = new JObject
            {
                { "num", 1 },
                { "year", "2020" },
                { "month", "9" },
                { "day", "9" },
                { "safe_title", "Test" },
                { "img", "http://test.com/" },
                { "alt", "Test" },
                { "transcript", "Test" }
            };
            return jobject.ToString();
        }
    }
}
