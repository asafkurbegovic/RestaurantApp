using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    public class MockDataStore : IDataStore<User>
    {
        readonly List<User> items;

        public MockDataStore()
        {
            items = new List<User>()
            {
                new User { Id = Guid.NewGuid().ToString(), FirstName = "Asaf", LastName="Kurbegovic", Username ="asaf", Password="string" },
                new User { Id = Guid.NewGuid().ToString(), FirstName = "Absaf", LastName="BKurbegovic", Username ="absaf", Password="string"},
                new User { Id = Guid.NewGuid().ToString(), FirstName = "Abcsaf", LastName="CKurbegovic", Username ="abcsaf", Password="string" },
                new User { Id = Guid.NewGuid().ToString(), FirstName = "Abcdsaf", LastName="DKurbegovic", Username ="abcdsaf", Password="string" }
                
            };
        }

        public async Task<bool> AddItemAsync(User item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = items.Where((User arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((User arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}