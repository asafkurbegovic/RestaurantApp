using RestaurantApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;

namespace RestaurantApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        //<summary>
        // Klikom na "naruci" button poziva se ordercommand koja incijalizira toast obavijest o 
        // uspjesnoj narudzbi
        //</summary>
        private async void OrderCommand(System.Object sender, System.EventArgs e)
        {
            await this.DisplayToastAsync("Narudžba uspješno završena", 1000);
        }
    }
}