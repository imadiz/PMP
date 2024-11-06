namespace osztalyok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladat1();
            Feladat3();
            Feladat4();
            Console.ReadKey();
        }
        static void Feladat1()
        {
            Book b = new Book("J.R.R Tolkien", "The Hobbit - or There and Back Again", 1937, 312);
            Console.WriteLine(b.AllData());
            Task.Delay(1000).Wait();
        }
        static void Feladat3()
        {
            Runner Elso = new Runner("Ernő", "1", 1.5, 1);
            Runner Masodik = new Runner("Miklós", "2", 2, 3);

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Elso.Show();
                Elso.RefreshDistance(1);

                Masodik.Show();
                Masodik.RefreshDistance(i);
                Task.Delay(500).Wait();
            }
            Task.Delay(1000).Wait();
            Console.Clear();
        }
        static void Feladat4()
        {
            Crypto Cryption = new Crypto(5);

            Console.Write("Kérek egy üzenetet: ");
            string input = Console.ReadLine();

            Console.WriteLine($"Titkosítva: {Cryption.Encode(input)}");
            Console.WriteLine($"Dekódolva: {Cryption.Decode(Cryption.Encode(input))}");
        }
    }
}
