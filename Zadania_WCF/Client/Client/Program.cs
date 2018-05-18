using Client.Cosmos;
using Client.Imperium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {

        static FirstOrderClient imperium = new Imperium.FirstOrderClient();
        static CosmosServiceClient cosmos = new CosmosServiceClient();

        static List<Starship> _starships = new List<Starship>();

        static bool _anySystem = true;
        static int _gold = 900;
        static int _imperiumMoneyAskCount = 5;

        static void Main(string[] args)
        {

            cosmos.InitializeGame();

            char key;
            while (true)
            {

                printMenu();
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key)
                {
                    case 'x':
                        HandleExit();
                        return;
                    case '1':
                        HandleAskForGold();
                        break;
                    case '2':
                        HandleShipPurchase();
                        break;
                    case '3':
                        HandleShipSending();
                        break;
                    case '4':
                        ListShips();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Czekaj na kolejna ture...");
                Thread.Sleep(2 * 1000);
            }

            void printMenu()
            {
                Console.Clear();
                Console.WriteLine($"Gold: {_gold}  |  Pozostałe czeki na złoto: {_imperiumMoneyAskCount}");
                Console.WriteLine("1 - Poproś imperium o złoto");
                Console.WriteLine("2 - Kup statek za złoto");
                Console.WriteLine("3 - Wyślij statek do systemu");
                Console.WriteLine("4 - Wypisz statki");
                Console.WriteLine("x - Zakończ grę");
            }
        }

        static void HandleExit()
        {
            if (!_anySystem)
                Console.WriteLine("Wygrana");
            else
                Console.WriteLine("Przegrana");
        }

        static void HandleAskForGold()
        {
            if (_imperiumMoneyAskCount == 0)
            {
                Console.WriteLine("Wyczerpałeś swoje prośby o złoto!");
                return;
            }
            _gold += imperium.GetMoneyFromImperium();
            _imperiumMoneyAskCount--;
        }

        static void HandleShipPurchase()
        {
            Console.WriteLine($"Aktualne złoto: {_gold}. Wpisz za ile złota chcesz kupić statek");

            if (!Int32.TryParse(Console.ReadLine(), out int enteredMoney))
            {
                Console.WriteLine("Wpisałeś niepoprawną liczbę.");
                return;
            }

            if (enteredMoney > _gold)
                Console.WriteLine("Nie możesz wydać więcej niż masz");
            else
            {
                var ship = cosmos.GetStarship(enteredMoney);
                _starships.Add(ship);
                _gold -= enteredMoney;
            }
        }

        static void HandleShipSending()
        {
            var system = cosmos.GetSystem();
            if (system == null)
            {
                _anySystem = false;
                return;
            }
            Console.WriteLine($"System {system.Name}, odległość: {system.BaseDistance}");

            if (_starships.Count == 0) return;

            Console.WriteLine($"Statków gotowych do podróży: {_starships.Count}");
            Console.WriteLine("Wybierz statek wpisując jego numer (albo wyjdź wypisując '0'):");
            ListShips();

            var key = Console.ReadLine();

            var option = Convert.ToInt32(key);
            if (option == 0) return;

            if (option <= _starships.Count)
            {

                var ship = _starships[option - 1];
                _starships.Remove(ship);
                var returnedShip = cosmos.SendStarship(ship, system.Name);
                if (returnedShip.Gold != 0)
                {
                    _gold += returnedShip.Gold;
                    returnedShip.Gold = 0;
                }
                if (returnedShip.Crew.Count() > 0)
                {
                    _starships.Add(returnedShip);
                }
            }
        }

        static void ListShips()
        {
            if (_starships.Count == 0)
            {
                Console.WriteLine("Nie masz na razie żadnych statków");
                Thread.Sleep(2300);
                return;
            }
            int counter = 1;
            _starships.ForEach(ship =>
            {
                Console.WriteLine($"{counter++}. ${ship.ShipPower} | {ship.Crew.Select(x => $" {x.Name} ({x.Nick}, {x.Age})").Aggregate((a, b) => a + ", " + b)}");
            });
        }
    }
}
