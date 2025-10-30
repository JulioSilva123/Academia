using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jft.ToDoXamarinForm.Services
{
    public interface IDataStore<T>
    {
        bool AddItem(T item);
        bool UpdateItem(T item);
        bool DeleteItem(string id);
        T GetItem(string id);
        IEnumerable<T> GetItems(bool forceRefresh = false);
    }

    public interface IDataStoreAsync<T>
    {

        Task<bool> SaveItemAsync(T item);
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        Task<T> GetItemAsync(int id);
        Task<List<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetItemsAsyncEnumerable(bool forceRefresh = false);
    }



}
