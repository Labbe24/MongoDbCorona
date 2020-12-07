using MongoDB.Driver;
using MongoDbCoronaTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbCoronaTest
{
    public class DbClient
    {
        public DbClient(MongoClient client)
        {
            Db = client.GetDatabase("CoronaDb");
            Citizens = Db.GetCollection<Citizen>("Citizens");
            Municipalities = Db.GetCollection<Municipality>("Municipalities");
            Locations = Db.GetCollection<Location>("Locations");
            TestCenters = Db.GetCollection<TestCenter>("TestCenters");
        }
        private IMongoDatabase Db;

        public IMongoCollection<Citizen> Citizens;
        public IMongoCollection<Municipality> Municipalities;
        public IMongoCollection<Location> Locations;
        public IMongoCollection<TestCenter> TestCenters;
    }
}
