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

        //<summary>
        // Klikom na register pojavljiva se taost i screen se vraca na login
        //</summary>
        public async void RegisteredCommand(System.Object sender, System.EventArgs e)
        {
            await this.DisplayToastAsync("Registration completed", 1000);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}