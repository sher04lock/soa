using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Book : IDBObject
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
        [JsonIgnore]
        public int PageCount { get; set; }
    }
}
