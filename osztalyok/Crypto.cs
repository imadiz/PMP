using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osztalyok
{
    public class Crypto
    {
        int Key { get; set; }
        private string TransformMessage(string message, int key)
        {
            string output = "";
            byte[] asciicodes = Encoding.ASCII.GetBytes(message);
            

            for (int i = 0; i < asciicodes.Length; i++)
            {
                asciicodes[i] = Convert.ToByte(asciicodes[i] + key);
            }
            return Encoding.ASCII.GetString(asciicodes);
        }

        public string Decode(string message)
        {
            return TransformMessage(message, -Key);
        }

        public string Encode(string message)
        {
            return TransformMessage(message, Key);
        }
        public Crypto(int key)
        {
            Key = key;
        }
    }
}
