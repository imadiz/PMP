namespace ConsoleSlayer;

public class GameItem
{
    public Position Position;
    public ConsoleSprite Sprite;
    public enum ItemType {Ammo, BFGCell, Door, LevelExit, Medikit, ToxicWaste, Wall}

    public ItemType Type;
    public double FillingRatio;
    public bool Available;

    private void SetInitialProperties()
    {
        ConsoleColor fg;
        ConsoleColor bg;
        FillingRatio = 0.0;
        char towrite;
        switch (Type)
        {
            case ItemType.Ammo:
                fg = ConsoleColor.Yellow;
                bg = ConsoleColor.Red;
                towrite = 'A';
                break;
            case ItemType.BFGCell:
                fg = ConsoleColor.White;
                bg = ConsoleColor.Green;
                towrite = 'B';
                break;
            case ItemType.Door:
                FillingRatio = 1.0;
                fg = FillingRatio.Equals(1.0) ? ConsoleColor.Yellow : ConsoleColor.DarkYellow;
                bg = ConsoleColor.Gray;
                towrite = '/';
                break;
            case ItemType.LevelExit:
                FillingRatio = 1.0;
                fg = ConsoleColor.White;
                bg = ConsoleColor.Blue;
                towrite = 'E';
                break;
            case ItemType.Medikit:
                fg = ConsoleColor.Red;
                bg = ConsoleColor.DarkGray;
                towrite = '+';
                break;
            case ItemType.ToxicWaste:
                fg = ConsoleColor.Yellow;
                bg = ConsoleColor.DarkGreen;
                towrite = ':';
                break;
            case ItemType.Wall:
                FillingRatio = 1.0;
                fg = ConsoleColor.Gray;
                bg = ConsoleColor.DarkGray;
                towrite = '.';
                break;
            default:
                return;
        }

        Sprite = new ConsoleSprite(fg, bg, towrite);
        Available = true;
    }

    public void Interact()
    {
        switch (Type)
        {
            case ItemType.BFGCell:
            case ItemType.Medikit:    
            case ItemType.Ammo:
                Available = false;
                break;
            case ItemType.Door:
                FillingRatio = FillingRatio.Equals(0.0) ? 1.0 : 0.0;
                Sprite = new ConsoleSprite(ConsoleColor.Gray,
                    FillingRatio.Equals(1.0) ? ConsoleColor.Yellow : ConsoleColor.DarkYellow, '/');
                break;
            
        }
    }

    public GameItem(int x, int y, ItemType type)
    {
        Position = new Position(x, y);
        Type = type;
        SetInitialProperties();
    }
}