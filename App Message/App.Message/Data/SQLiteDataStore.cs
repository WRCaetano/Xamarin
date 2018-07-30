using App.Message.Models;
using App.Message.Services;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(App.Message.Data.SQLiteDataStore))]
namespace App.Message.Data
{
    class SQLiteDataStore : IDataStore<Item>
    {
        readonly SQLiteAsyncConnection database;

        public SQLiteDataStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }

        public async Task<int> AddItemAsync(Item item)
        {
            if (item.Id != 0)
                return await database.UpdateAsync(item);
            else
                return await database.InsertAsync(item);
        }

        public async Task<int> UpdateItemAsync(Item item)
        {
            return await database.UpdateAsync(item);
        }

        public async Task<int> DeleteItemAsync(int id)
        {
            return await database.DeleteAsync(id);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await database.Table<Item>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await database.Table<Item>().ToListAsync();
        }
    }
}
