using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozgrzewka
{

    
    class Program
    {
        static int NWD(int a, int b)
        {
            while( b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        static int NWW(int a, int b)
        {
            return a * b / NWD(a, b);
        }

        static string Reverse(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);

        }

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Za malo argumentow");
            }

            if (args.Length == 1)
            {
                String text = args[0];
                Console.WriteLine("Masz, odwrocilem: ");

                Console.WriteLine(Reverse(text));
            }

            if (args.Length == 2)
            {
                try
                {
                    int number1 = Int32.Parse(args[0]);
                    int number2 = Int32.Parse(args[1]);
                    Console.WriteLine("NWW {0} i {1} to {2}", number1, number2, NWW(number1, number2));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
