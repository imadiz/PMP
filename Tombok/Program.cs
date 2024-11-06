using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Tombok
{
    internal class Program
    {
        static string[] AllCards = new string[52];
        static void Main(string[] args)
        {
            //feladat1();
            //feladat2();
            //feladat3();
            //feladat5();
            //feladat6();
            feladat8();
            feladat9();
            Console.ReadKey();
        }
        static void feladat1()
        {
            Console.WriteLine("1.feladat: ");
            string[] colors = { "Kőr", "Káró", "Treff", "Pikk" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jumbó", "Dáma", "Király", "Ász" };

            int cardsindex = 0;

            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    AllCards[cardsindex] = $"{colors[i]} {values[j]}";
                    cardsindex++;
                    Console.WriteLine(AllCards[cardsindex]);
                }
            }
            Console.WriteLine();
        }
        static void feladat2()
        {
            Console.WriteLine("2.feladat: ");
            string helper = "";
            int ToSwitchIndex = 0;
            Random rnd = new Random();

            for (int i = 0; i < 52; i++)
            {
                ToSwitchIndex = rnd.Next(i, AllCards.Length - 1);//Véletlen nem vizsgált elem
                helper = AllCards[ToSwitchIndex];//Eltárolás
                AllCards[ToSwitchIndex] = AllCards[i];//2 lépéses csere
                AllCards[i] = helper;
            }

            foreach (string item in AllCards)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
        static void feladat3()
        {
            Console.Write("3. feladat: Kérek egy darabszámot: ");
            int WordCount = int.Parse(Console.ReadLine());
            string[] Words = new string[WordCount];

            for (int i = 0;i < WordCount; i++)
            {
                Console.Write($"{i}. szó: ");
                Words[i] = Console.ReadLine();
            }

            Console.Write("Kérek egy szót: ");
            string SearchWord = Console.ReadLine();

            if (Words.Any(x => x.Equals(SearchWord)))
            {
                Console.WriteLine($"A '{SearchWord}' szó a {Array.IndexOf(Words, SearchWord)}. helyen található meg először.");
            }
            else
            {
                Console.WriteLine("Nincs ilyen szó a bekért szavak között.");
            }
        }
        static void feladat5()
        {
            List<string> AllNames = new List<string>();
            List<int> AllAges = new List<int>();
            List<bool> HasExperience = new List<bool>();

            while (true)
            {
                Console.Write("Kérek egy nevet: ");
                string Name = Console.ReadLine();

                if (Name.Length.Equals(0))
                {
                    break;
                }
                Console.Write("Kérek egy életkort: ");
                int Age = int.Parse(Console.ReadLine());
                Console.Write("Van programozói tapasztalata? (true/false): ");
                bool hasExperience = bool.Parse(Console.ReadLine());

                AllNames.Add(Name);
                AllAges.Add(Age);
                HasExperience.Add(hasExperience);
            }

            int SumAge = 0;
            foreach (int currentage in AllAges)
            {
                SumAge += currentage;
            }

            Console.WriteLine($"Az átlagéletkor {SumAge / AllAges.Count}.");

            SumAge = 0;

            for (int i = 0; i < AllAges.Count; i++)
            {
                if (HasExperience[i].Equals(false))
                {
                    SumAge += AllAges[i];
                }
            }
            Console.WriteLine($"A programozói tapasztalattal rendelkezők átlagéletkora: {SumAge / HasExperience.Count(x => x.Equals(false))}");

            int FoundIndex = 0;
            int OldestIndex = 0;
            
            for(int i = 0; i < AllAges.Count; i++)
            {
                if (HasExperience[i].Equals(true))
                {
                    if (AllAges[OldestIndex] < AllAges[i])
                    {
                        OldestIndex = i;
                    }
                }
            }
            Console.WriteLine($"A legidősebb programozói tapasztalattal rendelkező személy neve {AllNames[OldestIndex]}");
        }
        static void feladat6()
        {
            Console.WriteLine("6.feladat: ");

            Random rnd = new Random();

            int[,] Numbers = new int[9, 9];

            for (int i = 0;i < Numbers.GetLength(0); i++)
            {
                for (int j = 0;j < Numbers.GetLength(1); j++)
                {
                    Numbers[i, j] = rnd.Next(0, 10);
                }
            }

            int[,] FlippedNumbers = new int[9, 9];

            for (int i = 0; i < Numbers.GetLength(0); i++)
            {
                for (int j = 0; j < Numbers.GetLength(1); j++)
                {
                    FlippedNumbers[j, i] = Numbers[i, j];
                }
            }

            for (int i = 0; i < Numbers.GetLength(0); i++)
            {
                for (int j = 0; j < Numbers.GetLength(1); j++)
                {
                    Console.Write($"{Numbers[i, j]} ");
                }
                Console.Write("\n");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < Numbers.GetLength(0); i++)
            {
                for (int j = 0; j < Numbers.GetLength(1); j++)
                {
                    Console.Write($"{FlippedNumbers[i, j]} ");
                }
                Console.Write("\n");
            }
        }
        static void feladat8()
        {
            List<int> Numbers = new List<int>();

            Console.Write("7.feladat: Kérek egy egész számot: ");
            int input = int.Parse(Console.ReadLine());

            Numbers.Add(input);
            do
            {
                Console.WriteLine(Numbers.Last());
                if ((Numbers.Last() % 2).Equals(0))
                {
                    Numbers.Add(Numbers.Last() / 2);
                }
                else
                {
                    Numbers.Add(3 * Numbers.Last() + 1);
                }
            } while (Numbers.Last() != 1);
            Console.WriteLine(Numbers.Last());
        }
        static void feladat9()
        {
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };

            for (int i = 0; i < x.Length; i++)
            {
                int tmp = x[i];
                x[i] = x[x.Length - i - 1];
                x[x.Length - i - 1] = tmp;//El kellett venni az i-ből 1-et.
            }
        }
    }
}
