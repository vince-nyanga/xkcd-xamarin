using System;
using Xamarin.Forms;
using XKCDApp.Services;
using XKCDApp.ViewModels;

namespace XKCDApp
{
    public partial class MainPage : ContentPage
    {
        public ComicViewModel ViewModel { get; set; }  

        public MainPage(ComicViewModel viewModel)
        {

            ViewModel = viewModel;
            InitializeComponent();
            BindingContext = ViewModel;
            ViewModel.Initialize();
        }
    }
}
