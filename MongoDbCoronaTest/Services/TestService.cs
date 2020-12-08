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
    public class TestService
    {
        private readonly DbClient client;
        public TestService(DbClient client)
        {
            this.client = client;
        }

        public void TestCitizen(int id, int testCenterId)
        {
            var rand = new Random();
            string testResult = rand.Next(0, 2) > 0 ? "positive" : "negative";
            var updatedCitizen = client.Citizens.FindOneAndDelete(c => c.CitizenId == id);
            int testId = updatedCitizen.Tests.Count;

            updatedCitizen.Tests.Add(new Test { TestId = testId, Result = testResult, Status = "done", Date = DateTime.Now, TestCenter_Id = testCenterId });
            client.Citizens.InsertOne(updatedCitizen);

            var updatedTestCenter = client.TestCenters.FindOneAndDelete(t => t.TestCenterId == testCenterId);
            updatedTestCenter.Citizen_id.Add(updatedCitizen.CitizenId);
            client.TestCenters.InsertOne(updatedTestCenter);
        }

        public void TestAllCitizens()
        {
            var rand = new Random();
            int range = (int)client.TestCenters.CountDocuments(_ => true);

            if(range <= 0)
            {
                Console.WriteLine("No TestCenters exists");
                return;
            }

            var citizens = client.Citizens.Find(_ => true).ToList();

            foreach (var citizen in citizens)
            {
                TestCitizen(citizen.CitizenId, rand.Next(1, range + 1));
            }
        }
    }
}
