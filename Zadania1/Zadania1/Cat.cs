using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    public class Cat : Animal
    {
        string Color;

        public Cat(string Name = "Garfield") : base(Name) { }

        public override int CountLegs()
        {
            return 4;
        }

        public override string Sound()
        {
            return "meow";
        }

        public override string Trick()
        {
            return "sing";
        }
    }
}
