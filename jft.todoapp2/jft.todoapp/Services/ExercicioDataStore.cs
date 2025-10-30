using jft.todoapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jft.todoapp.Services
{
    public class ExercicioDataStore : IDataStore<ItemExercicio>
    {
        readonly List<ItemExercicio> items;

        public ExercicioDataStore()
        {
            items = new List<ItemExercicio>()
            {
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Supino Vertical", Rodada = "1º Rodada", Description="This is an item description." },
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Remada Máquina", Rodada = "1º Rodada", Description="This is an item description." },
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Peck Deck", Rodada = "1º Rodada", Description="This is an item description." },
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Rosca Martelo", Rodada = "1º Rodada", Description="This is an item description." },
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Peso Rosca", Rodada = "1º Rodada", Description="This is an item description." },
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Rodada = "1º Rodada", Description="This is an item description." },
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Senta e Levanta",Rodada = "1º Rodada",  Description="This is an item description." },
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Legpress",Rodada = "1º Rodada",  Description="This is an item description." },

                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora",Rodada = "2º Rodada", Description="This is an item description." },
                new ItemExercicio { Id = Guid.NewGuid().ToString(), Text = "Hack", Rodada = "2º Rodada",  Description="This is an item description." }
               

            };
        }

        public async Task<bool> AddItemAsync(ItemExercicio item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemExercicio item)
        {
            var oldItem = items.Where((ItemExercicio arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemExercicio arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemExercicio> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemExercicio>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}