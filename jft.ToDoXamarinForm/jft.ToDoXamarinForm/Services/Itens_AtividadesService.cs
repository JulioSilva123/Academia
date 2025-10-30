using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jft.ToDoXamarinForm.Services
{
    public class Itens_AtividadesService : IDataStoreAsync<itens_atividade>
    {
        public Itens_AtividadesService()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<Itens_AtividadesService> Instance = new AsyncLazy<Itens_AtividadesService>(async () =>
        {
            var instance = new Itens_AtividadesService();
            CreateTableResult result = await Database.CreateTableAsync<itens_atividade>();
            return instance;
        });
        public Task<bool> AddItemAsync(itens_atividade item)
        {
            Database.InsertAsync(item);

            return Task.FromResult(true);

        }

        public Task<bool> DeleteItemAsync(itens_atividade item)
        {
            Database.DeleteAsync(item);
            return Task.FromResult(true);
        }

        public Task<itens_atividade> GetItemAsync(int id)
        {
            return Database.Table<itens_atividade>().Where(i => i.id_item_atividade == id).FirstOrDefaultAsync();
        }

        public Task<List<itens_atividade>> GetItemsAsync(bool forceRefresh = false)
        {
            return Database.Table<itens_atividade>().ToListAsync();
        }

        public async Task<IEnumerable<itens_atividade>> GetItemsAsyncEnumerable(bool forceRefresh = false)
        {
            return await Database.Table<itens_atividade>().ToListAsync();
        }

        public Task<bool> SaveItemAsync(itens_atividade item)
        {
            if (item.id_item_atividade != 0)
            {
                return this.UpdateItemAsync(item);
            }
            else
            {
                return this.AddItemAsync(item);
            }
        }

        public Task<bool> UpdateItemAsync(itens_atividade item)
        {
            Database.UpdateAsync(item);
            return Task.FromResult(true);
        }
    }
}
