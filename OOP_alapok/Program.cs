using System.Linq;

namespace OOP_alapok
{
    public enum FlightStatus
    {
        Scheduled,
        Delayed,
        Canceled
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Console.ReadKey();
        }
        static void Feladat1()
        {
            Mole CurrentMole = new Mole();
            int input = 0;
            do
            {
                Console.Clear();
                CurrentMole.Hide(1, 5);
                Console.Write("Elbújt a vakond az 1-től 5-ig számozott lyukak valamelyikébe!\nTippelj, hogy melyikben lehet: ");
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Nem helyes értéket adtál meg! Nyomd meg bármelyik gombot az újrapróbáláshoz.");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine();

                Console.Write(" OOOOO");
                CurrentMole.TurnUp();

                Console.WriteLine();
                Console.WriteLine();

                if (input.Equals(CurrentMole.Position))
                {
                    Console.WriteLine("Eltaláltad! A játéknak vége van.");
                    break;
                }
                else
                {
                    Console.WriteLine("Nem ott bújt el a vakond, nyomj egy gombot a folytatáshoz.");
                    Console.ReadKey();
                }
            } while (true);
        }
        static void Feladat2()
        {
            GroundControl gc = new GroundControl();
            gc.AddFlight(new Flight(1, "NYC", DateTime.Now));
            gc.AddFlight(new Flight(2, "Brooklyn", new DateTime(2024, 11, 10, 10, 10, 10)));
            gc.AddFlight(new Flight(2, "Oslo", new DateTime(2024, 10, 30, 18, 45, 50)));

            gc.DisplayFlightData();
            gc.AllFlights[0].Cancel();

            foreach (Flight item in gc.AllFlights.Skip(2))
            {
                item.Delay(new Random().Next(60));
                item.UpdateStatus();
            }

            gc.DisplayFlightData();
        }
        static void Feladat3()
        {
            Console.WriteLine();
            Console.Write("Kérek egy számot: ");
            int num = int.Parse(Console.ReadLine());

            List<ExamResult> AllResults = [];

            for (int i = 0; i < num; i++)
            {
                AllResults.Add(new ExamResult());
            }

            Console.WriteLine("Sikeres dolgozatot írók: ");

            foreach (ExamResult item in AllResults.Where(x=>x.Passed))
            {
                Console.WriteLine(item.NeptunId);
            }

            Console.WriteLine($"Az átlagpontszám {AllResults.Average(x=>x.Percent)}.");
            Console.WriteLine($"A legmagasabb pontszámot {AllResults.First(y=> y.Percent.Equals(AllResults.Max(x => x.Percent))).NeptunId} érte el.");
        }
    }
}