using System;

class Printer
{
    public void IAmPrinting(GeometricShape shape)
    {
        Console.WriteLine(shape.ToString());
    }

    public void IAmPrinting(ControlElements element)
    {
        Console.WriteLine(element.ToString());
    }
}