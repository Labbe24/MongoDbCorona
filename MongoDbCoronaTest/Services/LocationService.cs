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
    public class LocationService
    {
        private readonly DbClient client;

        public LocationService(DbClient client)
        {
            this.client = client;
        }

        public void AddLocation(int citizenId, string address, int zip, string name)
        {
            var location = client.Locations.Find(l => l.Address == address && l.Zip == zip).FirstOrDefault();
            var municipality = client.Municipalities.Find(m => m.Name == name).FirstOrDefault();

            if (municipality == null)
            {
                Console.WriteLine("No municipality with name '{0}' exists.", name);
                return;
            }

            if (location != null)
            {
                var updatedLocation = client.Locations.FindOneAndDelete(l => l == location);
                updatedLocation.Registered.Add(new Registered { CitizenId = citizenId, Date = DateTime.Now });
                client.Locations.InsertOne(updatedLocation);
            }
            else
            {
                location = new Location
                {
                    Address = address,
                    Zip = zip,
                    LocationId = (int)client.Locations.CountDocuments(l => l.LocationId >= 0)
                };
                location.Registered.Add(new Registered { CitizenId = citizenId, Date = DateTime.Now });
                client.Locations.InsertOne(location);

                // Insert new Location into Municipality
                var updatedMunicipality = client.Municipalities.FindOneAndDelete(m => m == municipality);
                updatedMunicipality.Location_id.Add(location.LocationId);
                client.Municipalities.InsertOne(municipality);
            }

            // Add LocationId into Citizens List
            var updateCitizen = client.Citizens.FindOneAndDelete(c => c.CitizenId == citizenId);
            updateCitizen.Location_id.Add(location.LocationId);
            client.Citizens.InsertOne(updateCitizen);
        }
    }
}
