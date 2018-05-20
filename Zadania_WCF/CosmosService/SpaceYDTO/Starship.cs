using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SpaceYDTO
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Starship" in both code and config file together.
    [DataContract]
    public class Starship
    {
        List<Person> crew;
        int gold;
        int shipPower;

        public Starship(List<Person> crew,  int shipPower)
        {
            this.gold = 0;
            this.crew = crew;
            this.shipPower = shipPower;
        }

        [DataMember]
        public List<Person> Crew
        {
            get { return crew; }
            set { crew = value; }
        }

        [DataMember]
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        [DataMember]
        public int ShipPower
        {
            get { return shipPower; }
            set { shipPower = value; }
        }
    }
}
