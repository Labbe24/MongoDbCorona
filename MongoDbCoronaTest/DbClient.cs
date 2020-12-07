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
        }
        private IMongoDatabase Db;

        public IMongoCollection<Citizen> Citizens;
        public IMongoCollection<Municipality> Municipalities;
    }
}
