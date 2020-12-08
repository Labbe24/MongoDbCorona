using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbCoronaTest.Models;

namespace MongoDbCoronaTest.Services
{
    public class CitizenService
    {
        private readonly DbClient client;
        public CitizenService(DbClient client)
        {
            this.client = client;
        }

        public void AddCitizen(Citizen newCitizen)
        {
            int id = (int)client.Citizens.CountDocuments(_ => true);

            newCitizen.CitizenId = id;
            client.Citizens.InsertOne(newCitizen);
        }
    }
}
