using Xamarin.Forms;
using XKCDApp.Views;

namespace XKCDApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new ComicView();
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
