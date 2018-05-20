using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Position
    {
        public int Gold { get; set; }
        [BsonId]
        public string Name { get; set; }
    }
}
