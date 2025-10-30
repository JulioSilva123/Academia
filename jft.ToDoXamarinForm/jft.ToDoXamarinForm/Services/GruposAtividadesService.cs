using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jft.ToDoXamarinForm.Services
{
    public class GruposAtividadesService : IDataStoreAsync<GruposAtividades>
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<GruposAtividadesService> Instance = new AsyncLazy<GruposAtividadesService>(async () =>
        {
            var instance = new GruposAtividadesService();
            CreateTableResult result = await Database.CreateTableAsync<GruposAtividades>();
            return instance;
        });

        public GruposAtividadesService()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }


        public Task<bool> SaveItemAsync(GruposAtividades item)
        {
            if (item.id_grupo_atividade != 0)
            {
                return this.UpdateItemAsync(item);
            }
            else
            {
                return this.AddItemAsync(item);
            }
        }


        public Task<bool> AddItemAsync(GruposAtividades item)
        {
            Database.InsertAsync(item);

            return Task.FromResult(true);

            //return Database.InsertAsync(item); 
        }
        public Task<bool> UpdateItemAsync(GruposAtividades item)
        {

            Database.UpdateAsync(item);
            return Task.FromResult(true);
            //throw new NotImplementedException();
        }


        public Task<bool> DeleteItemAsync(GruposAtividades item)
        {
            Database.DeleteAsync(item);
            return Task.FromResult(true);
        }




        public Task<GruposAtividades> GetItemAsync(int id)
        {
            return Database.Table<GruposAtividades>().Where(i => i.id_grupo_atividade == id).FirstOrDefaultAsync();
        }

        public Task<List<GruposAtividades>> GetItemsAsync(bool forceRefresh = false)
        {
            return Database.Table<GruposAtividades>().ToListAsync();
        }

        public async Task<IEnumerable<GruposAtividades>> GetItemsAsyncEnumerable(bool forceRefresh = false)
        {
            return await Database.Table<GruposAtividades>().ToListAsync();
        }









    }
}
