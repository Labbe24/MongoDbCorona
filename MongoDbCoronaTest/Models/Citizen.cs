using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbCoronaTest.Models
{
    public class Citizen
    {
        public Citizen()
        {
        }
        public Citizen(int citizenid, string firstname, string lastname, string ssn, int age, string sex)
        {
            CitizenId = citizenid;
            Firstname = firstname;
            Lastname = lastname;
            SSN = ssn;
            Age = age;
            Sex = sex;
            Tests = new List<Test>();
        }
        public ObjectId _id { get; set; }
        public int CitizenId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SSN { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int Municipality_id { get; set; }
        public List<Test> Tests { get; set; }
        public string[] TestCenter_id { get; set; }
        public string[] Location_id { get; set; }
    }
}
