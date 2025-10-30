using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jft.ToDoXamarinForm.Services
{
    public class TiposAtividadesService : IDataStoreAsync<TiposAtividades>
    {


        public TiposAtividadesService()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TiposAtividadesService> Instance = new AsyncLazy<TiposAtividadesService>(async () =>
        {
            var instance = new TiposAtividadesService();
            CreateTableResult result = await Database.CreateTableAsync<TiposAtividades>();
            return instance;
        });


        public Task<bool> AddItemAsync(TiposAtividades item)
        {
            Database.InsertAsync(item);

            return Task.FromResult(true);

        }

        public Task<bool> DeleteItemAsync(TiposAtividades item)
        {
            Database.DeleteAsync(item);
            return Task.FromResult(true);
        }

        public Task<TiposAtividades> GetItemAsync(int id)
        {
            return Database.Table<TiposAtividades>().Where(i => i.id_tipo_atividade == id).FirstOrDefaultAsync();
        }

        public Task<List<TiposAtividades>> GetItemsAsync(bool forceRefresh = false)
        {
            return Database.Table<TiposAtividades>().ToListAsync();
        }

        public async Task<IEnumerable<TiposAtividades>> GetItemsAsyncEnumerable(bool forceRefresh = false)
        {
            return await Database.Table<TiposAtividades>().ToListAsync();
        }

        public Task<bool> SaveItemAsync(TiposAtividades item)
        {
            if (item.id_tipo_atividade != 0)
            {
                return this.UpdateItemAsync(item);
            }
            else
            {
                return this.AddItemAsync(item);
            }
        }

        public Task<bool> UpdateItemAsync(TiposAtividades item)
        {
            Database.UpdateAsync(item);
            return Task.FromResult(true);
        }
    }
}
