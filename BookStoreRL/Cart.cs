﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL
{
   public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CartId { get; set; }

        public string UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string BookId { get; set; }

        public int OrderQuantity { get; set; }
    }
}
