using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbCoronaTest.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string result { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
    }
}
