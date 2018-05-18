using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    interface ICircus
    {
        string AnimalIntroduction();
        string Show();
        int Patter(int howMuch); // tupanie
    }
}
