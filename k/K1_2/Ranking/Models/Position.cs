using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Position
    {
        public int gold { get; set; }
        [BsonId]
        public string name { get; set; }
    }
}
