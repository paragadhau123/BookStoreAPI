﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookId { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string Quantity { get; set; }

        public string Image { get; set; }

    }
}