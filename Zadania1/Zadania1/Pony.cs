using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    public class Pony : Animal
    {
        bool isMagic;

        public override int CountLegs()
        {
            return 4;
        }

        public override string Sound()
        {
            return "ihaaa";
        }

        public override string Trick()
        {
            return "dance";
        }
    }
}
