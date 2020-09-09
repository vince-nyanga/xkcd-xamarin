using NSubstitute;
using XKCDApp.Services;
using XKCDApp.ViewModels;
using Xunit;

namespace XKCDApp.UnitTests.ViewModels
{
    public class ComicViewModelTests
    {
        private readonly IComicService _comicService;

        public ComicViewModelTests()
        {
            _comicService = Substitute.For<IComicService>();
        }

        [Fact]
        public async void LoadComicCommand_ShouldFetchComic()
        {
            var viewModel = CreateViewModel();
            var comicId = 1;

            viewModel.LoadComicCommand.Execute(comicId);

            await _comicService.Received().GetComic(comicId);
        }

        private ComicViewModel CreateViewModel()
        {
            return new ComicViewModel(_comicService);
        }
    }
}
