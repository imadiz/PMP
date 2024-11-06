using System.IO;
using System.Text;

namespace fajlok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void Feladat1()
        {
            foreach (string item in File.ReadAllLines("colored.txt", Encoding.Default))
            {
                string[] separated = item.Split('#');
                switch (separated[0])
                {
                    case "Red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "Blue":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    default:
                        break;
                }

                Console.WriteLine(separated[1]);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Feladat2()
        {
            DateOnly CurrentDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Random rnd = new Random();
            int[] WinnerNumbers = new int[5];
            do
            {
                for (int i = 0; i < 5; i++)
                {
                    int temp = rnd.Next(91);
                    if (WinnerNumbers.Any(x=>x.Equals(temp)))
                    {
                        WinnerNumbers[i] = rnd.Next(91);
                    }
                    else
                    {
                        WinnerNumbers[i] = temp;
                    }
                }

                Console.WriteLine($"On {CurrentDate:yyyy. MM. dd.} numbers were: {string.Join(' ', WinnerNumbers)}");

                File.WriteAllText($"{CurrentDate:yyyy-MM-dd}.txt", $"On {CurrentDate:yyyy. MM. dd.} numbers were: {string.Join(' ', WinnerNumbers)}");

                Console.WriteLine("Another week? [y/n]");
                CurrentDate = CurrentDate.AddDays(7);

            } while (!Console.ReadLine().Equals("n"));
        }
        static void Feladat3()
        {
            int count = File.ReadAllLines("NHANES_1999-2018.csv").Count();
            int[] id = new int[count];
            string[] time = new string[count];
            double[] gender = new double[count];//1=férfi, 2=nő
            double[] age = new double[count];
            double[] bmi = new double[count];
            double[] bloodsugar = new double[count];

            int index = 0;
            foreach (string item in File.ReadAllLines("NHANES_1999-2018.csv").Skip('1'))
            {
                string[] sep = item.Split(',');
                id[index] = int.Parse(sep[0]);
                time[index] = sep[1];
                gender[index] = double.Parse(sep[2], System.Globalization.CultureInfo.InvariantCulture);
                age[index] = double.Parse(sep[3], System.Globalization.CultureInfo.InvariantCulture);
                bmi[index] = double.Parse(sep[4], System.Globalization.CultureInfo.InvariantCulture);
                bloodsugar[index] = double.Parse(sep[5], System.Globalization.CultureInfo.InvariantCulture);
                index++;
            }

            string currenttime = time[0];

            int mencount = 0;
            double menbmisum = 0;

            int womencount = 0;
            double womenbmisum = 0;

            for (int i = 0; i < count; i++)
            {
                if (!time[i].Equals(currenttime))
                    break;

                if (gender[i].Equals(Convert.ToDouble(1)))
                {
                    mencount++;
                    menbmisum += bmi[i];
                }
                else
                {
                    womencount++;
                    womenbmisum += bmi[i];
                }
            }

            Console.WriteLine($"A nők bmi átlaga {(womenbmisum/womencount):0.00}, míg a férfiaké {(menbmisum/mencount):0.00}.");

            double headcount = 0;
            double highvaluecount = 0;

            for (int i = 0; i < count; i++)
            {
                if (!time[i].Equals(currenttime))
                    break;

                headcount++;

                if (bloodsugar[i] > 5.6)
                {
                    highvaluecount++;
                }
            }

            Console.WriteLine($"Az alanyok {Convert.ToDouble(highvaluecount / headcount):0.00}%-nak magas a vércukorszintje.");

            double maxbmi = 0;
            int maxindex = 0;

            for (int i = 0; i < count; i++)
            {
                if (maxbmi < bmi[i])
                {
                    maxbmi = bmi[i];
                    maxindex = i;
                }
            }

            Console.WriteLine($"A maximális BMI-vel({maxbmi}) rendelkező alanynak a vércukorszintje {bloodsugar[maxindex]}.");

            double agesum = 0;
            headcount = 0;

            for (int i = 0; i < count; i++)
            {
                if (bmi[i] < 30)
                {
                    continue;
                }

                agesum += age[i];
                headcount++;
            }

            Console.WriteLine($"A súlsúlyos emberek átlagéletkora {agesum/headcount:0.00}.");
        }
    }
}
