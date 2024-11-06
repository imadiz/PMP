namespace PMPHF011
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wordnum = Convert.ToInt32(Console.ReadLine());//Keresett szavak száma
            List<string> Words = new();//keresett szavak

            for (int i = 0; i < wordnum; i++)//Szavak bekérése
            {
                Words.Add(Console.ReadLine());
            }

            string haystack = Console.ReadLine();//Szöveg, amiben történik a keresés
            int[] chars = new int[haystack.Length];//Keresett szöveg hosszú tömb, a keresett szavak betűinek jelzése (1-el) utána törlésre.
            int[] reversechars = new int[haystack.Length];

            for (int i = 0; i < chars.Length; i++)//Mindent 0-ra állítani
            {
                chars[i] = 0;
                reversechars[i] = 0;
            }

            string output = haystack;
            string reversehay = "";
            for (int i = haystack.Length - 1; i >= 0; i--)//Szöveg megfordítása
            {
                reversehay += haystack[i];
            }

            foreach (string item in Words)//Végighaladás a keresett szavakon
            {
                if (haystack.Contains(item))//Normál szöveg tartalmazza-e
                {
                    for (int i = haystack.IndexOf(item); i <= haystack.IndexOf(item) + item.Length - 1; i++)//Ha igen, jelöld
                    {
                        chars[i] = 1;
                    }

                    if (reversehay.Contains(item))//Megfordított szöveg tartalmazza-e
                    {
                        for (int i = reversehay.IndexOf(item); i <= reversehay.IndexOf(item) + item.Length - 1; i++)//Ha igen, jelöld
                        {
                            reversechars[i] = 1;
                        }
                    }
                }
                else if (reversehay.Contains(item))//Megfordított szöveg tartalmazza-e
                {
                    for (int i = reversehay.IndexOf(item); i <= reversehay.IndexOf(item) + item.Length - 1; i++)//Ha igen, jelöld
                    {
                        reversechars[i] = 1;
                    }
                }
            }

            int reverseindex = reversechars.Length - 1;//Megfordított tömb indexe

            char[] outarray = output.ToCharArray();//Kimenet összepakolása

            for (int i = 0; i < output.Length; i++)
            {
                if (chars[i].Equals(1))//A normál szövegben jelölve van-e
                {
                    outarray[i] = '%';//Ha igen, jelölés törlésre
                }

                if (reversechars[reverseindex].Equals(1))//A fordított szövegben jelölve van-e
                {
                    outarray[i] = '%';//Ha igen, jelölés törlésre
                }
                reverseindex--;
            }

            output = new string(outarray);

            while (output.Contains('%'))
            {
                output = output.Remove(output.IndexOf('%'), 1);
            }
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
