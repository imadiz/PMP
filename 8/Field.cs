namespace _8;

public class Field
{
    private int FieldSize { get; }
    public int TargetX => FieldSize;
    public int TargetY => FieldSize;

    public bool AllowedPosition(int x, int y)
    {
        if (x >= FieldSize || y >= FieldSize) return false;

        return x < FieldSize && y < FieldSize;
    }

    public void Show()
    {
        for (int i = 0; i <= FieldSize; i++)
        {
            if (i != FieldSize)
            {
                Console.WriteLine(new string(' ', FieldSize - 1)+"|");
            }
            else
            {
                Console.WriteLine(new string('-', FieldSize));
            }
        }
    }

    public Field(int size)
    {
        FieldSize = size;
    }
    
}