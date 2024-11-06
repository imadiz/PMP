namespace ConsoleSlayer;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Game jatek = new();
        jatek.Items.Add(new GameItem(3, 4, GameItem.ItemType.Wall));
        jatek.Items.Add(new GameItem(3, 2, GameItem.ItemType.Wall));
        jatek.Items.Add(new GameItem(2, 3, GameItem.ItemType.Wall));
        jatek.Items.Add(new GameItem(4, 3, GameItem.ItemType.Wall));
        jatek.Run();
    }
}