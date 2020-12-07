using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbCoronaTest.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int TestCenter_Id { get; set; }
    }
}
