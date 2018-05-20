using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SpaceYDTO;

namespace CosmosService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CosmosService : ICosmosService
    {
        private List<SpaceSystem> _systems;

        public Starship GetStarship(int money)
        {
            Person a = new Person("Antony", "Antony123");
            Person b = new Person("Balrog", "Balrog_X");
            Person c = new Person("Clemens", "Clementinto");
            Person d = new Person("Dann", "DannIchKann");

            List<Person> crew = new List<Person> { a, b, c, d };

            Random r = new Random();
            int shipPower;
            if (money > 1000 && money <= 3000)
                shipPower = r.Next(10, 25);
            else if (money > 3001 && money <= 10000)
                shipPower = r.Next(20, 35);
            else if (money > 10000)
                shipPower = r.Next(35, 60);
            else
                shipPower = r.Next(61, 70);

            return new Starship(crew, shipPower);
        }

        public SpaceSystem GetSystem()
        {
            _systems.DefaultIfEmpty(null);
            return _systems.FirstOrDefault();
        }

        public void InitializeGame()
        {
            _systems = new List<SpaceSystem>
            {
                new SpaceSystem("Weeshka"),
                new SpaceSystem("Videletz"),
                new SpaceSystem("Cubec"),
                new SpaceSystem("Talesh")
            };
        }

        public Starship SendStarship(Starship starship, string systemName)
        {
            var system = _systems.SingleOrDefault(x => x.Name == systemName);

            if (system == null)
            {
                starship.Crew.Clear();
                return starship;
            }

            starship.Crew.ForEach(member =>
            {
                if (starship.ShipPower <= 20)
                    member.Age += 2 * system.BaseDistance / 12;
                else if (starship.ShipPower > 20 && starship.ShipPower <= 30)
                    member.Age += 2 * system.BaseDistance / 6;
                else if (starship.ShipPower > 30)
                {
                    member.Age += 2 * system.BaseDistance / 4;
                }
                else member.Age += 2 * system.BaseDistance / 2;
            });

            starship.Crew.RemoveAll(member => member.Age > 90);

            if (starship.ShipPower >= system.minShipPower)
            {
                starship.Gold += system.gold;
                _systems.Remove(system);
            }

            return starship;
        }        
    }
}
