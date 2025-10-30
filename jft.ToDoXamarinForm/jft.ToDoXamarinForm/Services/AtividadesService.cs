using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jft.ToDoXamarinForm.Services
{
    public class AtividadesService : IDataStoreAsync<Atividades>
    {


        public AtividadesService()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<AtividadesService> Instance = new AsyncLazy<AtividadesService>(async () =>
        {
            var instance = new AtividadesService();
            CreateTableResult result = await Database.CreateTableAsync<Atividades>();
            return instance;
        });

        
        public Task<bool> AddItemAsync(Atividades item)
        {
            Database.InsertAsync(item);

            return Task.FromResult(true);

        }

        public Task<bool> DeleteItemAsync(Atividades item)
        {
            Database.DeleteAsync(item);
            return Task.FromResult(true);
        }

        public Task<Atividades> GetItemAsync(int id)
        {
            return Database.Table<Atividades>().Where(i => i.id_atividade == id).FirstOrDefaultAsync();
        }

        public Task<List<Atividades>> GetItemsAsync(bool forceRefresh = false)
        {
            return Database.Table<Atividades>().ToListAsync();
        }

        public async Task<IEnumerable<Atividades>> GetItemsAsyncEnumerable(bool forceRefresh = false)
        {
            return await Database.Table<Atividades>().ToListAsync();
        }

        public Task<bool> SaveItemAsync(Atividades item)
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

        public Task<bool> UpdateItemAsync(Atividades item)
        {
            Database.UpdateAsync(item);
            return Task.FromResult(true);
        }
    }
}
