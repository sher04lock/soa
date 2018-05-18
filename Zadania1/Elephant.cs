using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    class Elephant : Animal
    {
        public override int CountLegs()
        {
            return 4;
        }

        public override string Sound()
        {
            return "Tuuutuuuruuuu";
        }

        public override string Trick()
        {
            return "roll";
        }
    }
}
