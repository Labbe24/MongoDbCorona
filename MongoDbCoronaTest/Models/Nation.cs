using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MongoDbCoronaTest.Models
{

    public class Nation
    {
        public ObjectId _id { get; set; }
        public int NationId { get; set; }
        public string Name { get; set; }
        public object[] Municipality_id { get; set; }
    }
}
