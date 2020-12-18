using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCL.Models
{
   public class WishlistModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookId { get; set; }
    }
}
