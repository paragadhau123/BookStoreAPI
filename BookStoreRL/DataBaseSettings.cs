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
    }

    public interface IBookStoreDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string UsersCollectionName { get; set; }

        string BooksCollectionName { get; set; }


    }
}
