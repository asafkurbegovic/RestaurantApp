using RestaurantApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;

namespace RestaurantApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private string picture;
        private string price;
        public Command OrderCommands;

        public ItemDetailViewModel()
        {
            //OrderCommands = new Command(OrderCommand);
        }

        //private async void OrderCommand(System.Object sender, System.EventArgs e)
        //{
        //    await this.DisplayToastAsync("Narudžba uspješno završena", 1000);
        //}

        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        public string Picture
        {
            get => picture;
            set => SetProperty(ref picture, value);
        }


        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await ItemDataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Title;
                Description = item.Description;
                Price = item.Price;
                Picture = item.Picture;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
