using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    //<summary>
    // Klasa koja sadrzi primjer podataka koje bi imalo jelo u situaciji kada bi se jelo spremalo u bazu podataka. 
    // Pored primjera, klasa sadrzi implementaciju svih metoda iz interfacea.
    //</summary>
    public class MockDataStoreProducts : IDataStore<Item>
    {
        readonly List<Item> items;
        public MockDataStoreProducts()
        {
            items = new List<Item>()
            {
                new Item {Id = Guid.NewGuid().ToString(), Description = "Lepina sa kajmakom, 100g", Title = "Kajmak", Picture = "kajmak.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Jaja, šunka, kajmak, hrenovke, sudžuk", Title = "Dorucak", Picture = "dorucak.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Teleči steak", Title = "Beefsteak", Picture = "beef.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Čorba sa povrćem i teletinom", Title = "Bosanski sahan", Picture = "bosanski.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Teletina u lepini", Title = "Cudesa od mesa", Picture = "cudesa.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Lešo teleća koljenica", Title = "Koljenica", Picture = "koljenica.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Teleći medaljoni", Title = "Medaljoni", Picture = "medaljoni.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Mijesano meso", Title = "Mijesano meso", Picture = "mijesano.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Suho meso, sudžuk, sir, kajmak", Title = "Hladna plata", Picture = "plata.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Teleća pljeskavica", Title = "Pljeskavica", Picture = "pljeska.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Sarma", Title = "Sarma", Picture = "sarma.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Teletina sa rostilja s prilozima", Title = "Slatkiš", Picture = "slatkis.png", Price = "5"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Tomahawk", Title = "Tomahawk", Picture = "tomahawk.png", Price = "100"},
                new Item {Id = Guid.NewGuid().ToString(), Description = "Tuna steak", Title = "Tuna steak", Picture = "tuna.png", Price = "5"},
            };

        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}
