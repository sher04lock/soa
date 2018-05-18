using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpaceYDTO
{
    [DataContract]
    public class Person
    {
        public Person(string name = "Player", string nick = "Nick", float age = 20)
        {
            this.Name = name;
            this.Nick = nick;
            this.Age = age;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Nick { get; set; }
        [DataMember]
        public float Age { get; set; }        
    }
}
