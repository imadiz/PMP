namespace _8;
using static Program.Position;

public class Player
{
    public string name { get; }
    
    public Program.Position pos { get; }

    public override string ToString()
    {
        return $"{name}, {pos}";
    }

    public Player(string name, Program.Position pos)
    {
        this.name = name;
        this.pos = pos;
    }
}