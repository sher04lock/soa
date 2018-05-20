using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SpaceYDTO
{
    [DataContract]
    public class SpaceSystem
    {
        string name;
        int baseDistance;
        public int minShipPower;
        public int gold;

        public SpaceSystem(string name)
        {
            this.name = name;

            Random r = new Random();
            minShipPower = r.Next(10, 40);
            baseDistance = r.Next(20, 120);
            gold = r.Next(3 * 1000, 7 * 1000);
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int BaseDistance
        {
            get { return baseDistance; }
            set { baseDistance = value; }
        }        
    }
}
