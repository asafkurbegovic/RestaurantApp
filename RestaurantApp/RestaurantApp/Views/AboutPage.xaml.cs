using RestaurantApp.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        AboutViewModel _aboutViewModel;

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = _aboutViewModel = new AboutViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _aboutViewModel.OnAppearing();
        }
    }
}