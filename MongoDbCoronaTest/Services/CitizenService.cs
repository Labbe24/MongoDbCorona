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

        public List<Citizen> CitizensAtSameLocation(int infectedId)
        {
            var threeDaysPrior = DateTime.Now.AddDays(-3);

            var possibleInfectedLocations = client.Locations
                .Find(l => l.Registered.Any(r => r.CitizenId == infectedId && r.Date > threeDaysPrior))
                .ToList();

            var ids = possibleInfectedLocations.SelectMany(l => l.Registered.Select(r => r.CitizenId));

            List<Citizen> possibleInfectedCitizens = new List<Citizen>();

            foreach (var id in ids)
            {
                possibleInfectedCitizens.Add(client.Citizens.Find(c => c.CitizenId == id).SingleOrDefault());
            }

            return possibleInfectedCitizens;

        }
    }
}
