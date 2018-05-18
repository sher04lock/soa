using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    public class Giraffe : Animal
    {
        public override int CountLegs()
        {
            return 4;
        }

        public override string Sound()
        {
            return "girafffff";
        }

        public override string Trick()
        {
            return "neck dance";
        }
    }
}
