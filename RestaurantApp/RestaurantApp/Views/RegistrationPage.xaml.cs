using RestaurantApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel();
        }

        public async void RegisteredCommand(System.Object sender, System.EventArgs e)
        {
            await this.DisplayToastAsync("Registration completed", 1000);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}