﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    //<summary>
    // Genericki CRUD interface koji implementiraju klase 'MockDataStore' i 'MockDataStoreProduct' 
    // zbog jednostavnijeg manipulisanja podacima
    //</summary>
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
