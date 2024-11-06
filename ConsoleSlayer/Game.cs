namespace ConsoleSlayer;

public class Game
{
    public Player Jatekos = new(0, 0);
    public bool Exited = false;
    public List<GameItem> Items;

    public void RenderSingleSprite(Position pos, ConsoleSprite sprite)
    {
        if (pos.X < 0 || pos.Y < 0) return;
        if(pos.X >= Console.WindowWidth || pos.Y >= Console.WindowHeight) return;
        Console.SetCursorPosition(pos.X, pos.Y);
        Console.BackgroundColor = sprite.Background;
        Console.ForegroundColor = sprite.Foreground;
        Console.Write(sprite.Glyph);
    }

    private void RenderGame()
    {
        Console.CursorVisible = false;
        Console.ResetColor();
        Console.Clear();

        foreach (GameItem gameItem in Items)
        {
            RenderSingleSprite(gameItem.Position, gameItem.Sprite);
        }
        
        RenderSingleSprite(Jatekos.Position, Jatekos.Sprite);
    }

    private void CleanUpGameItems()
    {
        Items.RemoveAll(x => !x.Available);
    }

    private void UserAction()
    {
        if (!Console.KeyAvailable) return;
        
        ConsoleKeyInfo pressed = Console.ReadKey(true);
        switch (pressed.Key)
        {
            case ConsoleKey.Escape:
                Exited = true;
                break;
            case ConsoleKey.UpArrow:
                Move(Jatekos, new Position(Jatekos.Position.X, Jatekos.Position.Y - 1));
                break;
            case ConsoleKey.DownArrow:
                Move(Jatekos, new Position(Jatekos.Position.X, Jatekos.Position.Y + 1));
                break;
            case ConsoleKey.LeftArrow:
                Move(Jatekos, new Position(Jatekos.Position.X - 1, Jatekos.Position.Y));
                break;
            case ConsoleKey.RightArrow:
                Move(Jatekos, new Position(Jatekos.Position.X + 1, Jatekos.Position.Y));
                break;
        }
    }

    public void Run()
    {
        while (!Exited)
        {
            RenderGame();
            UserAction();
            Task.Delay(25).Wait();
        }
    }

    public List<GameItem> GetGameItemsWithinDistance(Position pos, double distance)
    {
        return Items.Where(x=>Position.Distance(x.Position, pos) <= distance).ToList();
    }

    public double GetTotalFillingRatio(Position pos)
    {
        return GetGameItemsWithinDistance(pos, 0).Sum(x=>x.FillingRatio);
    }

    public void Move(Player player, Position pos)
    {
        if (GetTotalFillingRatio(pos) < 1.0)
        {
            player.Position = pos;
        }
    }

    public Game()
    {
        Items = new List<GameItem>();
    }
}