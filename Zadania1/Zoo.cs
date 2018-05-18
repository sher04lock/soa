using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    public class Zoo : IZoo
    {
        public List<Animal> Animals;
        public string Name;

        public Zoo(string Name, List<Animal> Animals)
        {
            this.Name = Name;
            this.Animals = Animals;
        }

        public string Sounds()
        {
            return Animals
                 .Select(x => x.Sound())
                 .Aggregate((a, b) => a + ", " + b);
        }
    }
}
