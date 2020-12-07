using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MongoDbCoronaTest.Models
{

    public class Location
    {
        public Location()
        {
            Registered = new List<Registered>();
        }
        public ObjectId _id { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public List<Registered> Registered { get; set; }
    }


    public class Registered
    {
        public int CitizenId { get; set; }
        public DateTime Date { get; set; }
    }

}
