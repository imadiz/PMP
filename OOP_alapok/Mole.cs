using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_alapok
{
    public class Mole
    {
        int _pos;
        public int Position { get => _pos; }
        public void TurnUp()
        {
            Console.SetCursorPosition(Position, Console.CursorTop);
            Console.Write('M');
        }
        public void Hide(int min, int max)
        {
            _pos = new Random().Next(min, max + 1);
        }
    }
}
