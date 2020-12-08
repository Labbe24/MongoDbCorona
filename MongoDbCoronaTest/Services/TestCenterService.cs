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
    public class TestCenterService
    {
        private readonly DbClient client;

        public TestCenterService(DbClient client)
        {
            this.client = client;
        }

        public void AddTestCenter(string name, int hours, int phonenumber, string email)
        {
            var updatedMunicipality = client.Municipalities.FindOneAndDelete(m => m.Name == name);

            if (updatedMunicipality == null)
            {
                Console.WriteLine("No municipality with name '{0}' exists.", name);
                return;
            }

            var testcenter = new TestCenter
            {
                TestCenterId = (int)client.TestCenters.CountDocuments(t => t.TestCenterId >= 0),
                Hours = hours,
                TestCenterManagement = new Testcentermanagement { Phonenumber = phonenumber, Email = email }
            };
            client.TestCenters.InsertOne(testcenter);

            updatedMunicipality.TestCenter_id.Add(testcenter.TestCenterId);
            client.Municipalities.InsertOne(updatedMunicipality);
        }

        public int ActiveCovidCasesByMunicipalityName(string name)
        {
            var activeDate = DateTime.Now.AddDays(-14);
            var municipality = client.Municipalities.Find(m => m.Name == name).FirstOrDefault();
            if (municipality == null)
            {
                Console.WriteLine("No municipality with name '{0}' exists.", name);
                return 0;
            }
            int municipalityId = municipality.MunicipalityId;
            var cases = client.Citizens.Find(c => c.Municipality_id == municipalityId && c.Tests.Any(t => t.Date >= activeDate && t.Result == "positive")).ToList();

            return cases.Count;
        }

        public void ActiveCovidCasesPerMunicipality()
        {
            var municipalities = client.Municipalities.Find(m => m._id != null).ToList();

            Console.WriteLine("Municipality | Total number of Covid19 cases");
            Console.WriteLine("============================================");

            foreach (var municipality in municipalities)
            {
                int cases = ActiveCovidCasesByMunicipalityName(municipality.Name);
                Console.WriteLine("{0}: {1}", municipality.Name, cases);
            }
        }

        public void ActiveCovidCasesSex()
        {
            var maleCases = client.Citizens.Find(c => c.Sex == "male" && c.Tests.Any(t => t.Result == "positive")).ToList();
            var femaleCases = client.Citizens.Find(c => c.Sex == "female" && c.Tests.Any(t => t.Result == "positive")).ToList();
            var eitherCases = client.Citizens.Find(c => c.Sex == "either" && c.Tests.Any(t => t.Result == "positive")).ToList();

            int maleCount = maleCases.Count;
            int femaleCount = femaleCases.Count;
            int eitherCount = eitherCases.Count;

            Console.WriteLine("Males infected: {0}", maleCount);
            Console.WriteLine("Females infected: {0}", femaleCount);
            Console.WriteLine("Either infected: {0}", eitherCount);
        }

        public int ActiveCovidCasesAge(int minAge, int maxAge)
        {
            var cases = client.Citizens
                .Find(c => c.Age >= minAge && c.Age <= maxAge && c.Tests.Any(t => t.Result == "positive")).ToList();

            return cases.Count;
        }
    }
}
