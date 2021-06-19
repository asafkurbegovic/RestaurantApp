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

        private async void OrderCommand(System.Object sender, System.EventArgs e)
        {
            await this.DisplayToastAsync("Narudžba uspješno završena", 1000);
        }
    }
}