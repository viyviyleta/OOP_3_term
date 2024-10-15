using CustomExceptions;

public abstract partial class ControlElements
{
    public void MoveTo(ScreenPosition newPosition)
    {
        if (newPosition.X < 0 || newPosition.Y < 0)
            throw new InvalidPositionException("Новая позиция содержит недопустимые координаты.");

        Position = newPosition;
        Console.WriteLine($"{Name}, перемещен на позицию {Position}");
    }
}