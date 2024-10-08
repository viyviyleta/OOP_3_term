public struct ScreenPosition
{
    public int X { get; set; }
    public int Y { get; set; }

    public ScreenPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}";
    }
}