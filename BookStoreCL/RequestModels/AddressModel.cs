using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCL.RequestModels
{
   public class AddressModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AddressID { get; set; }

        public string UserId { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PinCode { get; set; }
    }
}
