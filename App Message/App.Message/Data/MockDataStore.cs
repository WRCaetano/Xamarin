using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Message.Models;
using App.Message.Services;

[assembly: Xamarin.Forms.Dependency(typeof(App.Message.Data.MockDataStore))]
namespace App.Message.Data
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            var description = "This is an item description for item";

            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = 1, Text = "Item Title #1".ToUpper(), Description = description},
                new Item { Id = 2, Text = "Item Title #2".ToUpper(), Description = description},
                new Item { Id = 3, Text = "Item Title #3".ToUpper(), Description = description},
                new Item { Id = 4, Text = "Item Title #4".ToUpper(), Description = description},
                new Item { Id = 5, Text = "Item Title #5".ToUpper(), Description = description},
            };

            foreach (var item in mockItems)
                items.Add(item);
        }

        async Task<int> IDataStore<Item>.AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(0);
        }

        async Task<int> IDataStore<Item>.UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(0);
        }

        public async Task<int> DeleteItemAsync(int id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(0);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }
        async Task<List<Item>> IDataStore<Item>.GetItemsAsync(bool forceRefresh)
        {
            return await Task.FromResult(items);
        }
    }
}