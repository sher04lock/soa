using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    public class Circus : ICircus
    {
        public List<Animal> Animals;
        public string Name;

        public Circus(List<Animal> Animals)
        {
            this.Animals = Animals;
        }

        public string AnimalIntroduction()
        {
            return Animals
                .Select(x => x.Sound())
                .Aggregate((a, b) => a + ", " + b);
        }

        public int Patter(int howMuch)
        {
            return Animals
                .Select(x => x.CountLegs() * howMuch)
                .Sum();
        }

        public string Show()
        {
            return Animals
                .Select(x => x.Trick())
                .Aggregate((a, b) => a + ", " + b);
        }
    }
}
