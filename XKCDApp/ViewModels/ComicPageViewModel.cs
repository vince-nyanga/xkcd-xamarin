using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using XKCDApp.Models;
using XKCDApp.Services;

namespace XKCDApp.ViewModels
{
    public class ComicPageViewModel : ViewModelBase
    {
        private readonly IComicService _comicService;
        private Comic _comic;
        public ICommand LoadComicCommand { get; }
        public int TotalComics => 614;
        public Comic Comic
        {
            get => _comic;
            set => SetProperty(ref _comic, value);
        }

        public ComicPageViewModel(IComicService comicService, INavigationService navigationService) : base(navigationService)
        {
            Title = "Comics";
            _comicService = comicService;
            LoadComicCommand = new DelegateCommand<int?>(GetComic, CanExecute);
        }

        private bool CanExecute(int? id)
        {
            return id.HasValue;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            GetComic(1);
        }

        private async void GetComic(int? id)
        {
            IsBusy = true;

            Comic = await _comicService.GetComic(id.Value);

            IsBusy = false;
        }
    }
}
