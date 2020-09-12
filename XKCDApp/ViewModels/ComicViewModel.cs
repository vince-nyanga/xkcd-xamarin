using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XKCDApp.Models;
using XKCDApp.Services;

namespace XKCDApp.ViewModels
{
    public class ComicViewModel : ViewModelBase
    {
        private readonly IComicService _comicService;
        private Comic _comic;
        public ICommand LoadComicCommand { get; }
        public int TotalComics => 614;
        public Comic Comic
        {
            get
            {
                return _comic;
            }
            set
            {
                _comic = value;
                OnPropertyChanged();
            }
        }

        public ComicViewModel(IComicService comicService)
        {
            _comicService = comicService;
            LoadComicCommand = new Command<int>(GetComic);
        }

        public override Task Initialize()
        {
            GetComic(1);
            return Task.CompletedTask;
        }

        private async void GetComic(int id)
        {
            IsBusy = true;

            Comic = await _comicService.GetComic(id);

            IsBusy = false;
        }

    
    }
}
