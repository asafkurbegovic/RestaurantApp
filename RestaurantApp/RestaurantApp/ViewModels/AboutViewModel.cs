using RestaurantApp.Models;
using RestaurantApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestaurantApp.ViewModels
{

    //<summary>
    // ViewModel folder sadrzi sve fajlove koji se ponasaju kao kontroleri u aplikaciji na nacin da upravljaju
    // kada i kako ce se prokazati podaci koje imamo u 'MockDataStore' i 'MockDataStoreProducts'. To sve se
    // odvija preko metoda kreiranih u interfaceu i implementiranih u servisima.
    //</summary>
    public class AboutViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }
        public AboutViewModel()
        {
            Console.WriteLine("loadaed");

            // naslov prikazanog screena
            Title = "Menu";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        //<summary>
        // Ucitavanje svih jela iz mock podataka.
        //</summary>
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await ItemDataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //<summary>
        // Postavljanje parametara prilikom ucitavanja screena
        //</summary>
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        //<summary>
        // Dodjeljivanje vrijednosti koje se nalaze u modelu jela koje je korisnik kliknuo
        //</summary>
        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        //<summary>
        // Preusmjeravanje na screen za dodavanje novih jela
        // NE MOZE SE KORISTIT JER NEMA LOGIKE DA GOST DODAJE JELA.
        //</summary>
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        //<summary>
        // Preusmjeravanje korisnika na screen sa detaljima jela koje je izabrao
        //</summary>
        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
