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

using StoreProductsSearch.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(FileSystemImplementation))]
namespace StoreProductsSearch.Droid
{
    public class FileSystemImplementation : IFileSystem
    {
        public string GetExternalStorage()
        {
            Context context = Android.App.Application.Context;
            ////storage/emulated/0/Android/data/com.companyname/files/Download
            ///This PC\Galaxy J5 Pro\Phone\Android\data\com.companyname\files\Download
            var filePath = context.GetExternalFilesDir("");
            return filePath.Path;
        }

        public string GetSpecialFolder()
        {
            var filePath = System.Environment.SpecialFolder.LocalApplicationData.ToString();
            return filePath;
        }
    }
}