
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// sqlite-net-pd (1.7.335)
using SQLite;

namespace StoreProductsSearch
{
    public class ProductItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ProductItemDatabase()
        {
            // the task extentsion method is located class TaskExtensions
            InitializeAsync().SafeFireAndForget(false);
            
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ProductItem).Name))
                {
                    //
                    // Summary:
                    //     Executes a "create table if not exists" on the database for each type. It also
                    //     creates any specified indexes on the columns of the table. It uses a schema automatically
                    //     generated from the specified type. You can later access this schema by calling
                    //     GetMapping.
                    //
                    // Returns:
                    //     Whether the table was created or migrated for each type.
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ProductItem)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<ProductItem>> GetItemsAsync()
        {
            return Database.Table<ProductItem>().ToListAsync();
        }

        //public Task<List<ProductItem>> GetItemsNotDoneAsync()
        //{
        //    return Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}
        public Task<List<ProductItem>> GetItemsSearch(string Item)
        {
            return Database.QueryAsync<ProductItem>("SELECT * FROM [ProductItem] WHERE [ProductName] LIKE '%" + Item + "%'");
        }
        public Task<ProductItem> GetItemAsync(int id)
        {
            return Database.Table<ProductItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ProductItem item)
        {
            if (item.ID != 0)
            {
                item.UpdateDate = DateTime.Now;
                return Database.UpdateAsync(item);
            }
            else
            {
                item.CreateDate = DateTime.Now;
                item.UpdateDate = DateTime.Now;
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ProductItem item)
        {
            return Database.DeleteAsync(item);
        }

    }
}
