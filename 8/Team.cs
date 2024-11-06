namespace _8;

public class Team
{
    Player?[] Players { get; set; } = new Player[5];

    public int NumberOfPlayers
    {
        get => Players.Count(x => x != null);
    }

    public bool IsFull
    {
        get => NumberOfPlayers == 5;
    }

    public bool IsIncluded(Player p)
    {
        return Players.Contains(p);
    }

    public bool IsAvailable(Player p)
    {
        switch (p.pos)
        {
            case Program.Position.Forward:
            case Program.Position.Goalkeeper:
            case Program.Position.Defender:
                return !Players.Any(x=>x.pos.Equals(p.pos));
            case Program.Position.Winger:
                return Players.Count(x => x.pos.Equals(p.pos)) < 2;
            default:
                return false;
        }
    }

    public void Include(Player p)
    {
        if (IsFull || IsIncluded(p) || !IsAvailable(p)) return;
        
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] is null)
            {
                Players[i] = p;
            }
        }
    }
    
}