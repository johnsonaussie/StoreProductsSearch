using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace StoreProductsSearch
{
    public class ProductItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }      
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Location { get; set; }
        public float Price { get; set; }
    }
}
