using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osztalyok
{
    public class Runner
    {
        private string Name { get; set; }
        private string Id { get; set; }
        private double Speed { get; set; }
        private int DistanceFromStart { get; set; } = 0;
        public int Row { get; set; }
        public void RefreshDistance(int passedseconds)
        {
            DistanceFromStart += Convert.ToInt32(Speed * passedseconds);
        }
        public void Show()
        {
            Console.SetCursorPosition(DistanceFromStart, Row);
            Console.Write(Name[0]);
        }
        public int GetDistance()
        {
            return DistanceFromStart;
        }
        public Runner(string name, string id, double speed, int row)
        {
            Name = name;
            Id = id;
            Speed = speed;
            Row = row;
        }
    }
}
