using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XKCDApp.Models;
using XKCDApp.Services;

namespace XKCDApp.ViewModels
{
    public class ComicViewModel : INotifyPropertyChanged
    {
        private readonly IComicService _comicService;
        private Comic _comic;

        public event PropertyChangedEventHandler PropertyChanged;

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
            LoadComicCommand = new Command<double>(GetComic);
        }

        public void Initialize()
        {
            GetComic(1);
        }

        private async void GetComic(double id)
        {
            Comic = await _comicService.GetComic((int)id);
        }

        private void OnPropertyChanged([CallerMemberName] string key = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
    }
}
