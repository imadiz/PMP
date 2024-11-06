namespace _8;

public class Program
{
    public enum Position
    {
        Goalkeeper,
        Forward,
        Winger,
        Defender
    }

    static Player[] RandomPlayers(int numberOfPlayers)
    {
        Player[] players = new Player[numberOfPlayers];
        
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = new($"Játékos #{i}", (Position)new Random().Next(0,4));
        }

        return players;
    }
    static void Main(string[] args)
    {
        Game jatek = new Game(12, 3);
        jatek.Run();
    }
}