using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbCoronaTest.Models
{
    public class Municipality
    {
        public Municipality()
        {}
        public Municipality(int id, string name, int population)
        {
            MunicipalityId = id;
            Name = name;
            Population = population;
            Location_id = new List<int>();
            TestCenter_id = new List<int>();
        }
        public Municipality(int id, string name, int population, int locationId)
        {
            MunicipalityId = id;
            Name = name;
            Population = population;
            Location_id = new List<int>();
            Location_id.Add(locationId);
            TestCenter_id = new List<int>();
        }

        public ObjectId _id { get; set; }
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public List<int> Location_id { get; set; }
        public List<int> TestCenter_id { get; set; }
    }
}
