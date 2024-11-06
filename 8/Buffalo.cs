namespace _8;

public class Buffalo
{
    public int PosX = 0;
    public int PosY = 0;
    public bool IsActive = true;

    public void Move(Field current)
    {
        int NewX = 0;
        int NewY = 0;
        do
        {
            switch (new Random().Next(3))
            {
                case 0:
                    NewX = PosX + 1;
                    break;
                case 1:
                    NewY = PosY + 1;
                    break;
                case 2:
                    NewX = PosX + 1;
                    NewY = PosY + 1;
                    break;
            }
        } while (!current.AllowedPosition(NewX, NewY));
        PosX = NewX;
        PosY = NewY;
    }

    public void Show()
    {
        Console.ForegroundColor = IsActive ? ConsoleColor.Green : ConsoleColor.Red;
        Console.SetCursorPosition(PosX, PosY);
        Console.Write('B');
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}