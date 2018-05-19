using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Artist: IDBObject
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string ArtistSurname { get; set; }
    }
}
