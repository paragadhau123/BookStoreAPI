﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BookStoreCL
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PinCode { get; set; }


        public string Password { get; set; }

       // public string Role { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
