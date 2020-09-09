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
            var jobject = new JObject();
            jobject.Add("year", "2020");
            jobject.Add("month", "9");
            jobject.Add("day", "9");
            jobject.Add("safe_title", "Test");
            jobject.Add("img", "Test");
            jobject.Add("alt", "Test");
            jobject.Add("transcript", "Test");
            return jobject.ToString();
        }
    }
}
