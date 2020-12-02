using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCL.Models
{
   public class BookModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookId { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string Quantity { get; set; }

        public IFormFile Image { get; set; }

    }
}
 