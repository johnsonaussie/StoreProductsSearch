using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProductsSearch
{
    public interface IFileSystem
    {
        string GetExternalStorage();
        string GetSpecialFolder();
    }
}
