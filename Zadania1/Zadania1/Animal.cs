using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    abstract public class Animal
    {
        public string Name;
        float Weight;
        bool hasFur;

        public Animal(string Name = "John Doe")
        {
            this.Name = Name;
        }

        public abstract string Sound();
        public abstract string Trick();
        public abstract int CountLegs();

    }
}
