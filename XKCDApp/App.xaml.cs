using Xamarin.Forms;
using XKCDApp.Services;
using XKCDApp.ViewModels;

namespace XKCDApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IComicService, HttpComicService>();

            MainPage = new MainPage(new ComicViewModel(DependencyService.Resolve<IComicService>()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
