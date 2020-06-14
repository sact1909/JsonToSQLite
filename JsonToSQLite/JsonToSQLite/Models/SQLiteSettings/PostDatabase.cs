using JsonToSQLite.Models.SQLiteSettings.DbModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToSQLite.Models.SQLiteSettings
{
    public class PostDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public PostDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(PostDbModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(PostDbModel)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }





        public Task<List<PostDbModel>> GetItemsAsync()
        {
            return Database.Table<PostDbModel>().ToListAsync();
        }

        public Task<List<PostDbModel>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<PostDbModel>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<PostDbModel> GetItemAsync(int id)
        {
            return Database.Table<PostDbModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(PostDbModel item)
        {
            return Database.InsertAsync(item);
            //if (item.Id != 0)
            //{
            //    return Database.UpdateAsync(item);
            //}
            //else
            //{
            //    return Database.InsertAsync(item);
            //}
        }

        public Task<int> DeleteItemAsync(PostDbModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
