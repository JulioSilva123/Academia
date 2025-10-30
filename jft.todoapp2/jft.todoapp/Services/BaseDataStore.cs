using jft.todoapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jft.todoapp.Services
{
    public class BaseDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public BaseDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Supino Vertical", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Remada Máquina", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Peck Deck", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Rosca Martelo", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Peso Rosca", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Senta e Levanta", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Legpress", Description="This is an item description." },

                new Item { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cadeira Extensora", Description="This is an item description." }

            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
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
    }
}