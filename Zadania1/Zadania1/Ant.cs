using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    public class Ant : Animal
    {
        bool isQueen;
  
        public override int CountLegs()
        {
            return 12;
        }

        public override string Sound()
        {
            return "...";
        }

        public override string Trick()
        {
            return "one hand stand";
        }
    }
}
