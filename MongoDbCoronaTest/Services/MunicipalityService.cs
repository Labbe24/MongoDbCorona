using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace MongoDbCoronaTest.Services
{
    public class MunicipalityService
    {
        private readonly DbClient client;
        public MunicipalityService(DbClient client)
        {
            this.client = client;
        }

        public int GetId(string name)
        {
            var municipality = client.Municipalities.Find(m => m.Name == name).FirstOrDefault();

            if (municipality == null)
            {
                return -1;
            }

            return municipality.MunicipalityId;
        }
    }
}
