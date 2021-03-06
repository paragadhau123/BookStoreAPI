﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL
{
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AdminId { get; set; }

        public string AdminName { get; set; }

        public string AdminEmailId { get; set; }

        public string AdminPassword { get; set; }

        public string AdminGender { get; set; }

        public string Token { get; set; }
    }
}
