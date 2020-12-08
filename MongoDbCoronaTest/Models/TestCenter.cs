using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MongoDbCoronaTest.Models
{

    public class TestCenter
    {
        public TestCenter()
        {
            Citizen_id = new List<int>();
        }

        public TestCenter(int id, int hours, int phonenumber, string email)
        {
            TestCenterId = id;
            Hours = hours;
            TestCenterManagement = new Testcentermanagement { Phonenumber = phonenumber, Email = email };
            Citizen_id = new List<int>();
        }
        public ObjectId _id { get; set; }
        public int TestCenterId { get; set; }
        public int Hours { get; set; }
        public List<int> Citizen_id { get; set; }
        public Testcentermanagement TestCenterManagement { get; set; }
    }


    public class Testcentermanagement
    {
        public int Phonenumber { get; set; }
        public string Email { get; set; }
    }

}
