using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Animals = new List<Animal>
            {
                new Cat("Garfield"), new Giraffe(), new Pony(), new Ant()
            };
            var Circus = new Circus(Animals);
            var Zoo = new Zoo("MojeZoo", Animals);
            var info = $"1 - Prezentacja zwierzat w cyrku {Circus.Name} \n" +
                $"2 - Obejrzenie programu cyrku w cyrku {Circus.Name} \n" +
                $"3 - Posłuchanie dźwięków Zoo {Zoo.Name} \n" +
                $"4 - Wyświetl imię pierwszego znalezionego futrzaka w Zoo \n" +
                $"5 - Wyświetl imiona wszystkich zwierzaków w Zoo {Zoo.Name} \n" +
                "x - wyjście z programu";
            Console.WriteLine(info);
            char key;
            while (true)
            {
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case 'x':
                        return;
                    case '1':
                        Console.WriteLine(Circus.AnimalIntroduction());
                        break;
                    case '2':
                        Console.WriteLine(Circus.Show());
                        break;
                    case '3':
                        Console.WriteLine(Zoo.Sounds());
                        break;
                    case '4':
                        var animal = Zoo.Animals.FirstOrDefault(x => x.Name == "Garfield");
                        Console.WriteLine(animal.Name);
                        break;
                    case '5':
                        var Names = Circus.Animals
                            .Select(x => x.Name)
                            .Aggregate((a, b) => a + ", " + b);
                        Console.WriteLine(Names);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
