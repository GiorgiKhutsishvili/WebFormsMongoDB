using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebFormsMongoDB.Models
{
    public class CarsInfo
    {
       
        public ObjectId _id { get; set; }
        public string Car { get; set; }
        public string CarModel { get; set; }
        public string ProductionYear { get; set; }
        public bool isDeleted { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}