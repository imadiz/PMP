namespace ConsoleSlayer;

public class ConsoleSprite(ConsoleColor bg, ConsoleColor fg, char glyph)
{
    public readonly ConsoleColor Background = bg;
    public readonly ConsoleColor Foreground = fg;
    public readonly char Glyph = glyph;
}