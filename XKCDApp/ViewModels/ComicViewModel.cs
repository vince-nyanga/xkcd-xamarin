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

        public ICommand LoadComicCommand => new Command<int>(GetCommic);

        public Comic Comic { get
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
        }

        private async void GetCommic(int id)
        {
           Comic = await _comicService.GetComic(id);
        }

        private void OnPropertyChanged([CallerMemberName] string key = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
    }
}
