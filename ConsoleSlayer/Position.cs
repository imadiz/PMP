using System.Net.Sockets;

namespace ConsoleSlayer;

public class Position(int x, int y)
{
    public int X = x;
    public int Y = y;

    public static Position Add(Position p_1, Position p_2)
    {
        return new Position(p_1.X + p_2.X, p_1.Y + p_2.Y);
    }

    public static double Distance(Position p_1, Position p_2)
    {
        return Math.Sqrt(Math.Pow(p_2.X - p_1.X, 2) + Math.Pow(p_2.Y - p_1.Y, 2));
    }
}