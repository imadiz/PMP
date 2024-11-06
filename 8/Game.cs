namespace _8;

public class Game
{
    private Field field;
    private List<Buffalo> buffalos = new();
    private bool IsOver;

    private void VisualizeElements()
    {
        Console.Clear();
        field.Show();
        foreach (Buffalo current in buffalos)
        {
            current.Show();
        }
    }

    public Game(int FieldSize, int NumberOfBuffalos)
    {
        field = new Field(FieldSize);
        for (int i = 0; i < NumberOfBuffalos; i++)
        {
            buffalos.Add(new());
        }
    }

    private void Shoot()
    {
        Console.SetCursorPosition(0, field.TargetY + 1);
        Console.WriteLine("Kérek egy x koordinátát:");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("Kérek egy y koordinátát:");
        int y = int.Parse(Console.ReadLine());
        foreach (Buffalo current in buffalos.Where(x=>x.PosX.Equals(x) && x.PosY.Equals(y)))
        {
            current.Deactivate();
        }
    }

    public void Run()
    {
        do
        {
            foreach (Buffalo current in buffalos.Where(x=>x.IsActive))
            {
                if (current.PosX == field.TargetX && current.PosX == field.TargetY)
                {
                    IsOver = true;
                }

                current.Move(field);
            }
            VisualizeElements();
            Shoot();
            if (!buffalos.Any(x=>x.IsActive))
            {
                IsOver = true;
            }
        } while (!IsOver);

        Console.WriteLine("Játék vége!");
    }
}