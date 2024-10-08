public abstract partial class ControlElements
{
    public void MoveTo(ScreenPosition newPosition)
    {
        Position = newPosition;
        Console.WriteLine($"{Name}, перемещен на позицию {Position}");
    }
}