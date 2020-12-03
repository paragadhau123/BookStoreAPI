using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL
{
    public class BookStoreDatabaseSettings : IBookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string UsersCollectionName { get; set; }

        public string BooksCollectionName { get; set; }

        public string AdminCollectionName { get; set; }

        public string WishListCollectionName { get; set; }

        public string CartCollectionName { get; set; }

        public string OrderCollectionName { get; set; }
    }


    public interface IBookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string UsersCollectionName { get; set; }

        public string BooksCollectionName { get; set; }

        public string AdminCollectionName { get; set; }

        public string WishListCollectionName { get; set; }

        public string CartCollectionName { get; set; }

        public string OrderCollectionName { get; set; }
    }
}
