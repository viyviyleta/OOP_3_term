using CustomExceptions;
public struct ScreenPosition
{
    public int X { get; set; }
    public int Y { get; set; }

    public ScreenPosition(int x, int y)
    {
        if (x < 0 || y < 0)
            throw new InvalidPositionException("Координаты позиции должны быть неотрицательными");

        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}";
    }
}