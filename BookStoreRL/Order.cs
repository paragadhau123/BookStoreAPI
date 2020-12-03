using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }

        public string CartId { get; set; }

        public string UserId { get; set; }

        public string BookId { get; set; }

        public string Quantity { get; set; }

        public string TotalPrice { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }


        public string Pincode { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
