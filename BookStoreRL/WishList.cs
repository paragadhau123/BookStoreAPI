using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL
{
    public class WishList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string WishListId { get; set; }

        public string UserId { get; set; }

        public string BookId { get; set; }
    }
}
