using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    class Circus : ICircus
    {
        List<Animal> Animals;
        string Name;

        public string AnimalIntroduction()
        {
            return Animals
                .Select(x => x.Sound())
                .Aggregate((a, b) => a + ", " + b);
        }

        public int Patter(int howMuch)
        {
            throw new NotImplementedException();
        }

        public string Show()
        {
            throw new NotImplementedException();
        }
    }
}
