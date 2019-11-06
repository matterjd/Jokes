using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Jokes.Data
{
    public class JokeDatabase
    {
        readonly SQLiteAsyncConnection database;
        public JokeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Jokes.Models.Joke>().Wait();
        }

        public Task<List<Jokes.Models.Joke>> GetItemsAsync()
        {
            return database.Table<Models.Joke>().ToListAsync();
        }
        
        public Task<List<Jokes.Models.Joke>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Models.Joke>("SELECT * FROM [Joke]");
        }

        public Task<Models.Joke> GetItemAsync(int id)
        {
            return database.Table<Models.Joke>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Models.Joke joke)
        {
            if (joke.ID != 0)
            {
                return database.UpdateAsync(joke);
            }
            else
            {
                return database.InsertAsync(joke);
            }
        }

        public Task<int> DeleteItemAsync(Models.Joke joke)
        {
            return database.DeleteAsync(joke);
        }

    }
}
