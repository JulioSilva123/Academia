using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jft.ToDoXamarinForm.Services
{
    public class DiariaAtividadesService   : IDataStoreAsync<DiariaAtividades>
    {


        public DiariaAtividadesService()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<DiariaAtividadesService> Instance = new AsyncLazy<DiariaAtividadesService>(async () =>
        {
            var instance = new DiariaAtividadesService();
            CreateTableResult result = await Database.CreateTableAsync<DiariaAtividades>();
            return instance;
        });


        public Task<bool> AddItemAsync(DiariaAtividades item)
        {
            Database.InsertAsync(item);

            return Task.FromResult(true);

        }

        public Task<bool> DeleteItemAsync(DiariaAtividades item)
        {
            Database.DeleteAsync(item);
            return Task.FromResult(true);
        }

        public Task<DiariaAtividades> GetItemAsync(int id)
        {
            return Database.Table<DiariaAtividades>().Where(i => i.id_diaria_atividade == id).FirstOrDefaultAsync();
        }

        public Task<List<DiariaAtividades>> GetItemsAsync(bool forceRefresh = false)
        {
            return Database.Table<DiariaAtividades>().ToListAsync();
        }

        public async Task<IEnumerable<DiariaAtividades>> GetItemsAsyncEnumerable(bool forceRefresh = false)
        {
            return await Database.Table<DiariaAtividades>().ToListAsync();
        }

        public Task<bool> SaveItemAsync(DiariaAtividades item)
        {
            if (item.id_atividade != 0)
            {
                return this.UpdateItemAsync(item);
            }
            else
            {
                return this.AddItemAsync(item);
            }
        }

        public Task<bool> UpdateItemAsync(DiariaAtividades item)
        {
            Database.UpdateAsync(item);
            return Task.FromResult(true);
        }
    }
}
