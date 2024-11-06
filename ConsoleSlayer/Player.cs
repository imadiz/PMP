namespace ConsoleSlayer;

public class Player(int x, int y)
{
    public Position Position = new(x, y);
    public readonly ConsoleSprite Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'O');
    public double FillingRatio = 0.5;
}