using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbCoronaTest.Models
{
    public class Municipality
    {
        public Municipality(int id, string name, int population)
        {
            MunicipalityId = id;
            Name = name;
            Population = population;
        }
        public ObjectId _id { get; set; }
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public object[] Location_id { get; set; }
    }
}
