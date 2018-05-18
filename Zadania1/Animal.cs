using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    abstract class Animal
    {
        string Name;
        float Weight;
        bool hasFur;

        public abstract string Sound();
        public abstract string Trick();
        public abstract int CountLegs();

    }
}
