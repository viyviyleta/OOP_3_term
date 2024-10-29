using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

public delegate void Move(int x, int y);
public class User
{
    public string Name { get; }
    public (int x, int y) Position { get; set; } = (0, 0);
    public double Scale { get; private set; } = 3.14;

    public  event Move MoveUser;
    public event Action<double> Compress;

    public User(string name)
    {
        Name = name;
    }

    public void MoveOn(int dx, int dy)
    {
        Position = (Position.x + dx, Position.y + dy);
        Console.WriteLine($"{Name} перемещен на ({dx}, {dy}). Текущая позиция: ({Position.x}, {Position.y})");
    }

    public void CompressOn(double factor)
    {
        if(factor < 0)
        {
            throw new ArgumentException("Коэффициент должен быть положительным");
        }

        Scale *= factor;
        Console.WriteLine($"{Name} сжат до масштаба {Scale}");
    }

    public void TriggerMove(int dx, int dy) => MoveUser?.Invoke(dx, dy);
    public void TriggerComress(double factor) => Compress?.Invoke(factor);
}

