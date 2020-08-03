using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;


namespace StoreProductsSearch.Droid
{
    public static class Constants
    {
        public const string DatabaseFilename = "ProductItemSQLite.db3";
        //// sqlite-net-pd (1.7.335)
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                Context context = Android.App.Application.Context;
                var basePath = context.GetExternalFilesDir("Download");
                //var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath.Path, DatabaseFilename);
            }
        }
        public static string SpecialFolder
        {
            get
            {
                var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                return basePath;
            }
        }
    }
}